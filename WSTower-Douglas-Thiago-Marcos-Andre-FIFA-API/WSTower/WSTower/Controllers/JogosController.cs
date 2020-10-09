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
    public class JogosController : ControllerBase
    {
        JogoRepository _Jogo { get; set; }

        public JogosController()
        {
            _Jogo = new JogoRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_Jogo.ListarTodosJogos());
        }

        [HttpPost]
        public IActionResult CadastrarJogo(Jogo jogo)
        {
            _Jogo.CadastrarJogo(jogo);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarJgos(int id,Jogo jogo)
        {
            _Jogo.Atualizar(id, jogo);

            return Ok();
        }

        [HttpGet("DataJogo/{dataJogo}")]
        public IActionResult DataJogo(string dataJogo)
        {

            return Ok(_Jogo.ListarPorData(dataJogo));
        }

        [HttpGet("Selecao/{NomeSelecao}")]
        public IActionResult Selecao(string NomeSelecao)
        {
            return Ok(_Jogo.ListarNomeSelecao(NomeSelecao));
        }
        [HttpGet("NomeEstadio/{nomeEstadio}")]
        public IActionResult NomeEstadio(string nomeEstadio)
        {
            return Ok(_Jogo.ListarPorEstadio(nomeEstadio));
        }

    }
}