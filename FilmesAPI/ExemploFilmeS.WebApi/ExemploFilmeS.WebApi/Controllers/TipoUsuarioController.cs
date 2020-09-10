using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExemploFilmeS.WebApi.Domains;
using ExemploFilmeS.WebApi.Interfaces;
using ExemploFilmeS.WebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExemploFilmeS.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _TipoUsuario { get; set; }

        public TipoUsuarioController()
        {
            _TipoUsuario = new TipoUsuarioRepository();
        }

        [HttpGet]
        public IActionResult ListarTipoUsuarios()
        {
            try
            {
                return Ok(_TipoUsuario.ListarTipoUsuarios());

            }
            catch (Exception e)
            {
                return BadRequest("Erro no sistema");
            }
        }

        [HttpPost]
        public IActionResult AdicionarTipoUsuario(TipoUsuario TipoUsuarioNovo)
        {
            try
            {
                if (TipoUsuarioNovo.NomeTipoUsuario != null)
                {
                    if (_TipoUsuario.Adicionar(TipoUsuarioNovo))
                    {
                        return Ok("TipoUsuario cadastrado com sucesso");
                    }
                    else
                    {
                        return BadRequest("Não foi possivel adcionar o TipoUsuario tente novamente");
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
        public IActionResult DeletarTipoUsuario(int id)
        {
            try
            {
                if (_TipoUsuario.Deletar(id))
                {
                    return Ok("TipoUsuario deletado com sucesso");
                }
                else
                {
                    return BadRequest("Não foi possivel achar um TipoUsuario no id informado");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("{id}")]//id do TipoUsuario
        public IActionResult AtualizarTipoUsuario(int id, TipoUsuario TipoUsuario)
        {
            try
            {
                if (_TipoUsuario.Atualizar(id, TipoUsuario))
                {
                    return Ok("TipoUsuario atualizado com sucesso");
                }
                else
                {
                    return BadRequest("Não foi possivel achar um TipoUsuario no id informado");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}