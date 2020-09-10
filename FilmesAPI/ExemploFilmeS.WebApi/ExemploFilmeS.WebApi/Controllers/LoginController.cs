using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExemploFilmeS.WebApi.Domains;
using ExemploFilmeS.WebApi.Interfaces;
using ExemploFilmeS.WebApi.Repository;
using ExemploFilmeS.WebApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExemploFilmeS.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _Usuario { get; set; }

        public LoginController()
        {
            _Usuario = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel lvm)
        {
            try
            {
                Usuario usuarioBuscado = _Usuario.Login(lvm.Email, lvm.Senha);
                if (usuarioBuscado == null)
                    return BadRequest("Email ou senha incorretos");

                return Ok("Bem vindo:" + usuarioBuscado.Nome);
            }catch(Exception e)
            {
                return BadRequest("Erro no sistema");
            }
        }
    }
}