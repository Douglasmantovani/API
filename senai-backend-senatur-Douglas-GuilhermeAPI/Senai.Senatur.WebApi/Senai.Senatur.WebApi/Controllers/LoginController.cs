using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using Senai.Senatur.WebApi.Repositories;
using Senai.Senatur.WebApi.ViewModel;

namespace Senai.Senatur.WebApi.Controllers
{
    
   

   
    [Produces("application/json")]

   
    [Route("api/[controller]")]

    
    [ApiController]
    public class LoginController : ControllerBase
    { 
        IUsuarioRepository _usuario { get; set; }

        
        public LoginController()
        {
            _usuario = new UsuarioRepository();
        }

        
        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {
            
            Usuario usuarioBuscado = _usuario.BuscarPorEmailSenha(login.Email, login.Senha);

            
            if (usuarioBuscado == null)
            {
                
                return NotFound("E-mail ou senha inválidos");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.IdTipousuario.ToString())
            };

            
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Senatur-chave-autenticacao"));

          
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            
            var token = new JwtSecurityToken(
                issuer: "Senatur.WebApi",                 // emissor do token
                audience: "Senatur.WebApi",               // destinatário do token
                claims: claims,                          // dados definidos acima
                expires: DateTime.Now.AddMinutes(30),    // tempo de expiração
                signingCredentials: creds                // credenciais do token
            );
            
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}