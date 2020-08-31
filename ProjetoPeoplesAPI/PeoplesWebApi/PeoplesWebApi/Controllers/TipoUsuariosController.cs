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
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuariosController : ControllerBase
    {
        TipoUsuarioRepository _TipoUsuario { get; set; }

        public TipoUsuariosController()
        {
            _TipoUsuario = new TipoUsuarioRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_TipoUsuario.ListarTodos());
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, TiposUsuario TipoUsuarios)
        {
            _TipoUsuario.Atualizar(id, TipoUsuarios);

            return Ok("Atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _TipoUsuario.Deletar(id);

            return Ok("TipoUsuario deletado");
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorID(int id)
        {
            return Ok(_TipoUsuario.BuscarPorID(id));
        }
    }
}