using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LojaDeGames.Domains;
using LojaDeGames.Repositories;
using LojaDeGames.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LojaDeGames.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        UsuarioRepository U { get; set; }

        public LoginController()
        {
            U = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel lvm)
        {
            try
            {
                Usuario UsuarioBuscado = U.Login(lvm);

                if (UsuarioBuscado == null)
                {
                    return BadRequest("Email ou senha incorretos");
                }

                var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, UsuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, UsuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, UsuarioBuscado.IdTipoUsuario.ToString())
            };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("LojaDeGames-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "LojaDeGames",                 // emissor do token
                    audience: "LojaDeGames",               // destinatário do token
                    claims: claims,                          // dados definidos acima
                    expires: DateTime.Now.AddMinutes(30),    // tempo de expiração
                    signingCredentials: creds                // credenciais do token
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}