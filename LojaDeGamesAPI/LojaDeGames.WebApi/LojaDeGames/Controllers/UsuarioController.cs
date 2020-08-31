using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using LojaDeGames.Domains;
using LojaDeGames.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeGames.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        UsuarioRepository _u { get; set; }

        public UsuariosController()
        {
            _u = new UsuarioRepository();
        }


        [HttpGet("MeuCarrinho")]
        [Authorize(Roles = "2")]
        public IActionResult MeuCarrinho()
        {
            var usr = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
            return Ok(_u.Meucarrinho(usr));
        }

        [HttpGet]
        [Authorize(Roles = "1")]
        public IActionResult ListarUsuarios()
        {
            var usr = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
            return Ok(_u.ListarUsuario(usr));
        }

        [HttpGet("Perfil")]
        [Authorize(Roles = "2")]
        public IActionResult Perfil()
        {
            var usr = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
            return Ok(_u.Perfil(usr));
        }

        //[HttpDelete("{id}")]
        //public IActionResult Deletar(int id)
        //{
        //    _u.Deletar(id);

        //    return Ok("Usuario Deletado");
        //}

       [Authorize]
        [HttpPut]
        public IActionResult Atualizar(Usuario usuario)
        {
            try
            {
                var usr = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                // Faz a chamada para o método e armazena em um objeto usuarioBuscado
                Usuario usuarioBuscado = _u.BuscarPorid(usr);

                // Verifica se o usuário foi encontrado
                if (usuarioBuscado != null)
                {
                    // Faz a chamada para o método
                    _u.Atualizar(usr, usuario);

                    // Retora a resposta da requisição 204 - No Content
                    return Ok("Usuario atualizado");
                }

                // Retorna a resposta da requisição 404 - Not Found com uma mensagem
                return NotFound("Nenhum usuário encontrado para o ID informado");
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }
    }
}