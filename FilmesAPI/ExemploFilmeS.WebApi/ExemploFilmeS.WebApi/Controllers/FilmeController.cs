using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExemploFilmeS.WebApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExemploFilmeS.WebApi.Repositories;
using ExemploFilmeS.WebApi.Repository;
using ExemploFilmeS.WebApi.Domains;

namespace ExemploFilmeS.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private IFilmeRepository _Filme { get; set; }

        public FilmeController()
        {
            _Filme = new FilmeRepository();
        }

        [HttpGet]
        public IActionResult ListarFilmes()
        {
            try
            {
                return Ok(_Filme.ListarFilmes());

            }catch(Exception e)
            {
                return BadRequest("Erro no sistema");
            }
        }

        [HttpPost]
        public IActionResult AdicionarFilme(Filme filmeNovo)
        {
            try
            {
                if (filmeNovo.NomeFilme != null || filmeNovo.DataLancamento != null || filmeNovo.Diretor != null || filmeNovo.IdGenero != 0)
                {
                    if (_Filme.Adicionar(filmeNovo))
                    {
                        return Ok("Filme cadastrado com sucesso");
                    }
                    else
                    {
                        return BadRequest("Não foi possivel adcionar o filme tente novamente");
                    }
                }
                else
                {
                    return BadRequest("Preencha todos os campos");
                }
            }
            catch(Exception e)
            {
                return BadRequest("Erro no sistema");
            }
        }

        [HttpDelete]
        public IActionResult DeletarFilme(int id)
        {
            try
            {
                if (_Filme.Deletar(id))
                {
                    return Ok("Filme deletado com sucesso");
                }
                else
                {
                    return BadRequest("Não foi possivel achar um filme no id informado");
                }
            }catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("{id}")]//id do filme
        public IActionResult AtualizarFilme(int id,Filme filme)
        {
            try
            {
                if (_Filme.Atualizar(id,filme))
                {
                    return Ok("Filme atualizado com sucesso");
                }
                else
                {
                    return BadRequest("Não foi possivel achar um filme no id informado");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}