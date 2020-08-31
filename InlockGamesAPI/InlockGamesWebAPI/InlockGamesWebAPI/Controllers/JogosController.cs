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
            return Ok(_Jogo.ListarJogos());
        }

        [HttpPost]
        public IActionResult Adicionar(Jogo jogo)
        {
            jogo.DataLan = Convert.ToDateTime(jogo.DataLan);

            _Jogo.Adicionar(jogo);

            return Ok("Jogo adicionado");
        }

        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            _Jogo.Deletar(id);

            return Ok("Jogo Deletado");
        }
        [HttpPut]
        public IActionResult Atualizar(int id,Jogo jogo)
        {
            _Jogo.Atualizar(id,jogo);

            return Ok("Jogo atualizado com sucesso");
        }

        [HttpGet("ListarComEstudio")]
        public IActionResult ListarComEstudio()
        {
            return Ok(_Jogo.ListarComEstudio());
        }


        
    }
}