using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
    public class PresencaController : ControllerBase
    {
        PresencaRepository Rep { get; set; }
        public PresencaController()
        {
            Rep = new PresencaRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(Rep.Listar());
            }
            catch (Exception e)
            {
                return BadRequest("Erro no sistema");
            }
        }


        [HttpGet("Minhas")]
        public IActionResult GetMy()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(Rep.ListarMinhas(idUsuario));
            }
            catch (Exception e)
            {
                return BadRequest("Erro no sistema");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Presenca status)
        {
            try
            {
                Rep.AprovarRecusar(id, status.Situacao);

                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpPost("Convidar")]
        public IActionResult Invite(Presenca convite)
        {
            try
            {
                Rep.Convidar(convite);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest("Erro no sistema");
            }
        }

        [HttpPost("Inscricao/{idEvento}")]
        public IActionResult Join(int idEvento)
        {
            try
            {
                Presenca inscricao = new Presenca()
                {
                    IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value),
                    IdEvento = idEvento,
                    Situacao = "Não confirmada"
                };

               Rep.Inscrever(inscricao);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest("Erro no sistema");
            }
        }
    }
}