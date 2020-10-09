using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Repositories;

namespace Senai.Senatur.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class UsuarioController : ControllerBase
    {
        UsuarioRepository _Usuario { get; set; }

        public UsuarioController()
        {
            _Usuario = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult get()
        {
            return Ok(_Usuario.ListarUsuarios());
        }

        [HttpPost]
        public IActionResult Post(Usuario NovoUsuario)
        {
            _Usuario.Cadastrar(NovoUsuario);

            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario UsuarioAtualizado)
        {
            _Usuario.AtualizarPorid(id, UsuarioAtualizado);
            return Ok();
        }
    }
}