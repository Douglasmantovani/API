using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gufi.WebApi.Domains;
using Gufi.WebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gufi.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class InstituicaoController : ControllerBase
    {
        InstituicaoRepository Rep { get; set; }
        public InstituicaoController()
        {
            Rep = new InstituicaoRepository();
        }

        [HttpGet]
        public IActionResult ListarInstituicao()
        {
            try
            {
                return Ok(Rep.ListarInstituicao());
            }
            catch (Exception e)
            {
                return BadRequest("Erro no sistema");
            }
        }

        [HttpPost]
        public IActionResult AdicionarInstituicao(Instituicao Instituicao)
        {
            try
            {
                if (Instituicao.NomeFantasia == null || Instituicao.Endereco == null || Instituicao.Cnpj == null)
                {
                    return BadRequest("Preencha todos os campos");
                }
                if (Rep.Adicionar(Instituicao))
                {
                    return Ok("Instituicao cadastrado com sucesso");
                }
                else
                {
                    return BadRequest("Não foi possivel cadastrar este Instituicao");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Erro no sistema");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarInstituicao(int id)
        {
            try
            {
                if (Rep.Deletar(id))
                {
                    return Ok("Instituicao deletado com sucesso");
                }
                else
                {
                    return BadRequest("Não foi possivel deletar este Instituicao");
                }

            }
            catch (Exception e)
            {
                return BadRequest("Erro no sistema");
            }
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarInstituicao(int id, Instituicao Instituicao)
        {
            try
            {
                if (Rep.Atualizar(id, Instituicao))
                {
                    return Ok("Instituicao atualizada com sucesso");
                }
                else
                {
                    return BadRequest("Não foi possivel atualizar,tente novamente");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Erro no sistema");
            }
        }
    }
}