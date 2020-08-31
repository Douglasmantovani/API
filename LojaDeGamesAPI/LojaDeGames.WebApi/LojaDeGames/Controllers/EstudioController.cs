using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaDeGames.Domains;
using LojaDeGames.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeGames.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        EstudioRepository _u { get; set; }

        public EstudiosController()
        {
            _u = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult ListarEstudios()
        {
            try
            {
                return Ok(_u.ListarEstudios());
            }
            catch (Exception ex)
            {
                return BadRequest("Não foi possivel listar os estudios");
            }
        }

        [HttpPost]
        public IActionResult AdicionaEstudio(Estudio estudio)
        {
            try
            {
                if (_u.BuscarEstudio(estudio))
                {
                    _u.Adcionar(estudio);
                    return Ok("Estudio adicionado");
                }
                else
                {
                    return BadRequest("Ja existe um estudio com esse nome");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Não foi possivel adicionar o estudio");
            }
        }
    }
}
