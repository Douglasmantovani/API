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
    public class EventoController : ControllerBase
    {
        EventoRepository Rep { get; set; }
        public EventoController()
        {
            Rep = new EventoRepository();
        }

        [HttpGet]
        public IActionResult ListarEvento()
        {
            try
            {
                return Ok(Rep.ListarEvento());
            }catch(Exception e)
            {
                return BadRequest("Erro no sistema");
            }
        }
        
        [HttpPost]
        public IActionResult AdicionarEvento(Evento evento)
        {
            try
            {
                if (evento.NomeEvento == null || evento.IdInstituicao == null || evento.Descricao == null || evento.Descricao == null || evento.IdTipoEvento == null || evento.AcessoLivre == null)
                {
                    return BadRequest("Preencha todos os campos");
                }
                if (Rep.Adicionar(evento))
                {
                    return Ok("Evento cadastrado com sucesso");
                }
                else
                {
                    return BadRequest("Não foi possivel cadastrar este evento");
                }
            }
            catch(Exception e)
            {
                return BadRequest("Erro no sistema");
            }            
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarEvento(int id)
        {
            try
            {
                if (Rep.Deletar(id))
                {
                    return Ok("Evento deletado com sucesso");
                }
                else
                {
                    return BadRequest("Não foi possivel deletar este evento");
                }

            }catch(Exception e)
            {
                return BadRequest("Erro no sistema");
            }
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarEvento(int id,Evento evento)
        {
            try
            {
                if (Rep.Atualizar(id,evento))
                {
                    return Ok("Evento atualizado com sucesso");
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
