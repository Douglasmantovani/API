using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InlockGamesWebAPI.Domains;
using InlockGamesWebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InlockGamesWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        UsuarioRepository _Usuario { get; set; }

        public UsuariosController()
        {
            _Usuario = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_Usuario.ListarUsuarios());
        }

        [HttpPost]
        public IActionResult Adicionar(Usuario usuario)
        {
            _Usuario.Adicionar(usuario);

            return Ok("Usuario adicionado");
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _Usuario.Deletar(id);

            return Ok("Usuario Deletado");
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id,Usuario usuario)
        {
            _Usuario.Atualizar(id, usuario);

            return Ok("Usuario atualizado com sucesso");
        }
        [HttpGet("BuscarPorTipoUsuario")]
        public IActionResult ListarComTipoUsuario()
        {
            return Ok(_Usuario.BuscarPorTipoUsuario());
        }
    }
}