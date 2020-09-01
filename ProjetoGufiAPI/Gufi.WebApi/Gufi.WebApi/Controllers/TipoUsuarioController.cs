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
    public class TipoUsuarioController : ControllerBase
    {
        TipoUsuarioRepository Rep { get; set; }

        public TipoUsuarioController()
        {
            Rep = new TipoUsuarioRepository();
        }

        [HttpGet]
        public IActionResult ListarTipoUsuario()
        {
            try
            {
                return Ok(Rep.ListarTipoUsuario());
            }
            catch (Exception e)
            {
                return BadRequest("Erro no sistema");
            }
        }

        [HttpPost]
        public IActionResult AdicionarTipoUsuario(TipoUsuario TipoUsuario)
        {
            try
            {
                if (TipoUsuario.TituloTipoUsuario == null)
                {
                    return BadRequest("Preencha todos os campos");
                }
                if (Rep.Adicionar(TipoUsuario))
                {
                    return Ok("TipoUsuario cadastrado com sucesso");
                }
                else
                {
                    return BadRequest("Não foi possivel cadastrar este TipoUsuario");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Erro no sistema");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarTipoUsuario(int id)
        {
            try
            {
                if (Rep.Deletar(id))
                {
                    return Ok("TipoUsuario deletado com sucesso");
                }
                else
                {
                    return BadRequest("Não foi possivel deletar este TipoUsuario");
                }

            }
            catch (Exception e)
            {
                return BadRequest("Erro no sistema");
            }
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarTipoUsuario(int id, TipoUsuario TipoUsuario)
        {
            try
            {
                if (Rep.Atualizar(id, TipoUsuario))
                {
                    return Ok("TipoUsuario atualizado com sucesso");
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