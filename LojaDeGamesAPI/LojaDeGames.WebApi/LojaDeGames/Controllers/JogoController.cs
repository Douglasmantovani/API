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
    public class JogosController : ControllerBase
    {
        JogoRepository _u { get; set; }

        public JogosController()
        {
            _u = new JogoRepository();
        }

        [HttpGet]
        public IActionResult ListarJogos()
        {
            try
            {
                return Ok(_u.ListarJogos());
            }
            catch (Exception ex)
            {
                return BadRequest("Nao foi possivel listar os Jogos");
            }
        }

        [HttpPost]
        public IActionResult AdicionaJogo(Jogo jogo)
        {
            try
            {
                if (_u.BuscarJogo(jogo))
                {
                    _u.Adcionar(jogo);
                    return Ok("Jogo adicionado");
                }
                else
                {
                    return BadRequest("Ja existe um jogo com esse nome");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Não foi possivel adicionar o Jogo");
            }
        }
        [HttpPut("{id}")]//id jogo
        public IActionResult Atualizar(int id, Jogo jogo)
        {
            if (_u.AtualizarPorId(id, jogo))
            {
                return Ok("Atualizado");
            }
            else
            {
                return BadRequest("falha");
            }
        }
    }
}
