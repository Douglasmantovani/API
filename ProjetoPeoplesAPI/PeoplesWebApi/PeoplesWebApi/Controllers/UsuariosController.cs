using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeoplesWebApi.Domains;
using PeoplesWebApi.Repositories;

namespace PeoplesWebApi.Controllers
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
            return Ok(_Usuario.ListarTodosUsuarios());
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuarios Usuarios)
        {
            _Usuario.Cadastrar(Usuarios);

            return Ok("Usuario cadastrado com sucesso");
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Usuarios Usuarios)
        {
            _Usuario.Atualizar(id, Usuarios);

            return Ok("Atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _Usuario.Deletar(id);

            return Ok("Usuario deletado");
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorID(int id)
        {
            return Ok(_Usuario.BuscarPorID(id));
        }
    }
}