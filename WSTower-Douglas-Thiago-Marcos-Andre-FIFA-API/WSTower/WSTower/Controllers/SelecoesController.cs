using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSTower.Repositories;

namespace WSTower.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SelecoesController : ControllerBase
    {
        SelecaoRepository _Selecao { get; set; }

        public SelecoesController()
        {
            _Selecao = new SelecaoRepository();
        }

        [HttpGet("ListarTodosSelecoes")]
        public IActionResult ListarTodosSelecoes()
        {
            return Ok(_Selecao.ListarTodos());
        }

        [HttpGet("ListarTodosJogador")]
        public IActionResult ListarTodosJogador()
        {
            return Ok(_Selecao.ListarComJogador());
        }

        [HttpGet("ListarTodosJogadorConfronto")]
        public IActionResult ListarTodosJogadorConfronto()
        {
            return Ok(_Selecao.ListarConfrontos());
        }
    }
}