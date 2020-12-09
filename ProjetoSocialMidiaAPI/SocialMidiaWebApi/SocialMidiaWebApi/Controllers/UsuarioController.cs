using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMidiaWebApi.Domains;
using SocialMidiaWebApi.Repositories;

namespace SocialMidiaWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        UsuarioRepository _u { get; set; }

        public UsuarioController()
        {
            _u = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult ListarMensagens()
        {
            return Ok(_u.ListarMensagens());
        }

        [HttpPost("{id}")]
        public IActionResult EnviarMensagem(int id,Mensagem mensagem)
        {
            int idUsuario = 2;
           if (_u.EnviarMensagem(mensagem, id,idUsuario))
            {
                return Ok("Mensagem enviada");
            }
            else
            {
                return BadRequest("Não foi possivel enviar a mensagem");
            }

        }
    }
}
