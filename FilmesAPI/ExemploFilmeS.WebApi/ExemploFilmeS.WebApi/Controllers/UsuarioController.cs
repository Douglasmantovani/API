using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExemploFilmeS.WebApi.Domains;
using ExemploFilmeS.WebApi.Interfaces;
using ExemploFilmeS.WebApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExemploFilmeS.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _Usuario { get; set; }

        public UsuarioController()
        {
            _Usuario = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult ListarUsuarios()
        {
            try
            {
                return Ok(_Usuario.ListarUsuarios());

            }
            catch (Exception e)
            {
                return BadRequest("Erro no sistema");
            }
        }

        [HttpPost]
        public IActionResult AdicionarUsuario(Usuario UsuarioNovo)
        {
            try
            {
                if (UsuarioNovo.Nome != null || UsuarioNovo.Email != null || UsuarioNovo.Senha != null)
                {
                    if (_Usuario.Cadastrar(UsuarioNovo))
                    {
                        return Ok("Usuario cadastrado com sucesso");
                    }
                    else
                    {
                        return BadRequest("Não foi possivel adcionar o Usuario tente novamente");
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
        public IActionResult DeletarUsuario(int id)
        {
            try
            {
                if (_Usuario.Deletar(id))
                {
                    return Ok("Usuario deletado com sucesso");
                }
                else
                {
                    return BadRequest("Não foi possivel achar um Usuario no id informado");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("{id}")]//id do Usuario
        public IActionResult AtualizarUsuario(int id, Usuario Usuario)
        {
            try
            {
                if (_Usuario.Atualizar(id, Usuario))
                {
                    return Ok("Usuario atualizado com sucesso");
                }
                else
                {
                    return BadRequest("Não foi possivel achar um Usuario no id informado");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}