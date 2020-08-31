using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaDeGames.Repositories;
using LojaDeGames.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeGames.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        UsuarioRepository _u { get; set; }

        public CadastroController()
        {
            _u = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Cadastro(CadastroViewModel cvm)
        {
            try
            {
                if (cvm.Email == null || cvm.Senha == null || cvm.Telefone == null || cvm.NomeUsuario == null)
                {
                    return BadRequest("Preencha todos os campos");
                }
                else
                {
                    if (_u.BuscarPorEmail(cvm.Email))
                    {
                        if (_u.Cadastrar(cvm.NomeUsuario, cvm.Email, cvm.Senha, cvm.Telefone))
                        {
                            return Ok("Usuario cadastrado");
                        }
                        else
                        {
                            return BadRequest("Não foi possivel Realizar o cadastro");
                        }
                    }
                    else
                    {
                        return BadRequest("Esse email ja existe");
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest("Não foi possivel efetuar o cadastro");
            }
        }
    }
}