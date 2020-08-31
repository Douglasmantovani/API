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
    public class EstudiosController : ControllerBase
    {
       EstudioRepository _Estudio { get; set; }

        public EstudiosController()
        {
            _Estudio = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_Estudio.ListarEstudio());
        }

        [HttpPost]
        public IActionResult Adicionar(Estudio Estudio)
        {
            _Estudio.Adicionar(Estudio);

            return Ok("Estudio adicionado");
        }

        [HttpGet("ListarComJogo")]
        public IActionResult ListarComJogos()
        {
            return Ok(_Estudio.ListarEstudioComJogo());
        }
    }
}