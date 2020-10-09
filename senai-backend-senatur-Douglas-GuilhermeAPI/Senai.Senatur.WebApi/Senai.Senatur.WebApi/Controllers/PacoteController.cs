using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using Senai.Senatur.WebApi.Repositories;

namespace Senai.Senatur.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class PacoteController : ControllerBase
    {
        IPacoteRepository _Pacote { get; set; }

        public PacoteController()
        {
            _Pacote = new PacoteRepository();
        }
        [Authorize]
        [HttpGet]
        public IActionResult get()
        {
            return Ok(_Pacote.Listar());
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Pacote NovoPacote)
        {
            _Pacote.Cadastrar(NovoPacote);

            return Ok();

        }
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id,Pacote PacoteAtualizado)
        {
            _Pacote.AtualizarPorid(id, PacoteAtualizado);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult getId(int id)
        {
            _Pacote.BuscarPorid(id);

            return Ok(_Pacote.BuscarPorid(id));
        }

        [HttpGet("GetOn")]
        public IActionResult getON()
        {
           return Ok(_Pacote.BuscarPorAtivo());
        }

        [HttpGet("GetOff")]
        public IActionResult getOff()
        {
            return Ok(_Pacote.BuscarPorInativo());
        }

        [HttpGet("ValorCrescente")]
        public IActionResult getOrder()
        {
            return Ok(_Pacote.BuscarPrecoCrescente());
        }
        [HttpGet("NomeCity/{nomeCidade}")]
        public IActionResult NomeCity(string nomeCidade)
        {
            return Ok(_Pacote.BuscarPeloNome(nomeCidade));
        }

        [HttpGet("ValoreDecrescente")]
        public IActionResult getOrderdesc()
        {
            return Ok(_Pacote.BuscarPrecoDecrescente());
        }
    }
}