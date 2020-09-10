using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExemploFilmeS.WebApi.Domains;
using ExemploFilmeS.WebApi.Interfaces;
using ExemploGeneroS.WebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExemploFilmeS.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private IGeneroRepository _Genero { get; set; }

        public GeneroController()
        {
            _Genero = new GeneroRepository();
        }

        [HttpGet]
        public IActionResult ListarGeneros()
        {
            try
            {
                return Ok(_Genero.ListarGeneros());

            }
            catch (Exception e)
            {
                return BadRequest("Erro no sistema");
            }
        }

        [HttpPost]
        public IActionResult AdicionarGenero(Genero GeneroNovo)
        {
            try
            {
                if (GeneroNovo.NomeGenero != null)
                {
                    if (_Genero.Adicionar(GeneroNovo))
                    {
                        return Ok("Genero cadastrado com sucesso");
                    }
                    else
                    {
                        return BadRequest("Não foi possivel adcionar o Genero tente novamente");
                    }
                }
                else
                {
                    return BadRequest("Preencha todos os campos");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Erro no sistema");
            }
        }

        [HttpDelete]
        public IActionResult DeletarGenero(int id)
        {
            try
            {
                if (_Genero.Deletar(id))
                {
                    return Ok("Genero deletado com sucesso");
                }
                else
                {
                    return BadRequest("Não foi possivel achar um Genero no id informado");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("{id}")]//id do Genero
        public IActionResult AtualizarGenero(int id, Genero Genero)
        {
            try
            {
                if (_Genero.Atualizar(id, Genero))
                {
                    return Ok("Genero atualizado com sucesso");
                }
                else
                {
                    return BadRequest("Não foi possivel achar um Genero no id informado");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}