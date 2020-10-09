using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSTower.Domains;
using WSTower.Interfaces;
using WSTower.Repositories;

namespace WSTower.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class JogadorController : ControllerBase
    {
        private IJogadorRepository _jogadorRepository;
        public JogadorController()
        {
            _jogadorRepository = new JogadorRepository();
        }


        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_jogadorRepository.ListarTodos());
            }
            catch(Exception error)
            {
                return BadRequest(error);
            }
        }



        [HttpGet("{nome}")]
        public IActionResult GetByNome(string nome)
        {
            try
            {
                Jogador jogadorBuscado = _jogadorRepository.BuscarPorNome(nome);

                if(jogadorBuscado != null)
                {
                    return Ok(jogadorBuscado);
                }

                return NotFound("nenhum jogador encontrado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
            
        }

      

    }
}
