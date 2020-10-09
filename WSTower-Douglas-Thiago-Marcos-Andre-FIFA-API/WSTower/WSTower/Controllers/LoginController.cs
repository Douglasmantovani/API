using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSTower.Domains;
using WSTower.Repositories;
using WSTower.ViewModel;

namespace WSTower.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        UsuarioRepository _Usuario { get; set; }

        public LoginController()
        {
            _Usuario = new UsuarioRepository();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel usuarioLogin)
        {
            Usuario UserAchado = _Usuario.Login(usuarioLogin.Email, usuarioLogin.Senha, usuarioLogin.Apelido);

            if(UserAchado!=null)
            {
                if (UserAchado.Senha == usuarioLogin.Senha)
                {
                    return Ok("Bem vindo:" + UserAchado.Apelido);
                }
                else
                {
                    return BadRequest("Senha incorreta");
                }
            }
            return BadRequest("Usuario nao encontrado");
        }

        [HttpPut("{id}")]
        public IActionResult TrocaSenha(int id,LoginViewModel Login)
        {
            _Usuario.AlterarSenha(id,Login);

            return Ok();
        }
    }
        
}