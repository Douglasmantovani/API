using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSTower.Domains;
using WSTower.Repositories;

namespace WSTower.Controllers
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
        public IActionResult ListarUsuario()
        {
            return Ok(_Usuario.ListarTodos());
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarUsuario(int id,Usuario usuarioAtualizado)
        {
            if(_Usuario.AlterarUsuario(id, usuarioAtualizado))
            {
                return Ok("Alterado com sucesso");
            }
            else
            {
                return BadRequest("Preencha os campos corretamente");
            }
        }
    }
}