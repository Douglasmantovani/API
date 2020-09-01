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
    public class TipoEventoController : ControllerBase
    {
        TipoEventoRepository Rep { get; set; }
        public TipoEventoController()
        {
            Rep = new TipoEventoRepository();
        }

        [HttpGet]
        public IActionResult ListarTipoEvento()
        {
            try
            {
                return Ok(Rep.ListarTipoEvento());
            }
            catch (Exception e)
            {
                return BadRequest("Erro no sistema");
            }
        }

        [HttpPost]
        public IActionResult AdicionarTipoEvento(TipoEvento TipoEvento)
        {
            try
            {
                if (TipoEvento.TituloTipoEvento == null)
                {
                    return BadRequest("Preencha todos os campos");
                }
                if (Rep.Adicionar(TipoEvento))
                {
                    return Ok("TipoEvento cadastrado com sucesso");
                }
                else
                {
                    return BadRequest("Não foi possivel cadastrar este TipoEvento");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Erro no sistema");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarTipoEvento(int id)
        {
            try
            {
                if (Rep.Deletar(id))
                {
                    return Ok("TipoEvento deletado com sucesso");
                }
                else
                {
                    return BadRequest("Não foi possivel deletar este TipoEvento");
                }

            }
            catch (Exception e)
            {
                return BadRequest("Erro no sistema");
            }
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarTipoEvento(int id, TipoEvento TipoEvento)
        {
            try
            {
                if (Rep.Atualizar(id, TipoEvento))
                {
                    return Ok("TipoEvento atualizado com sucesso");
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