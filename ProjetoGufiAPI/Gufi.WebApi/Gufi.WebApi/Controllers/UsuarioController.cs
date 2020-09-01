using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gufi.WebApi.Domains;
using Gufi.WebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gufi.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        UsuarioRepository Rep { get; set; }
        public UsuarioController()
        {
            Rep = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult ListarUsuario()
        {
            try
            {
                return Ok(Rep.ListarUsuario());
            }
            catch (Exception e)
            {
                return BadRequest("Erro no sistema");
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario Usuario)
        {
            try
            {
                if (Usuario.NomeUsuario == null|| Usuario.DataNascimento == null|| Usuario.Genero == null|| Usuario.Email == null|| Usuario.Senha == null)
                {
                    return BadRequest("Preencha todos os campos");
                }
                else if (Rep.VerificarSeUsuarioExiste(Usuario.Email, Usuario.NomeUsuario))
                {
                    if (Rep.Adicionar(Usuario))
                    {
                        return Ok("Usuario cadastrado com sucesso");
                    }
                    else
                    {
                        return BadRequest("Não foi possivel cadastrar este Usuario");
                    }
                }
                else
                {
                    return BadRequest("Este usuario ja foi cadastrado");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Erro no sistema");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarUsuario(int id)
        {
            try
            {
                if (Rep.Deletar(id))
                {
                    return Ok("Usuario deletado com sucesso");
                }
                else
                {
                    return BadRequest("Não foi possivel deletar este Usuario");
                }

            }
            catch (Exception e)
            {
                return BadRequest("Erro no sistema");
            }
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarUsuario(int id, Usuario Usuario)
        {
            try
            {
                if (Rep.Alterar(id, Usuario))
                {
                    return Ok("Usuario atualizado com sucesso");
                }
                else
                {
                    return BadRequest("Não foi possivel atualizar,tente novamente");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Erro no sistema");
            }
        }
    }
}