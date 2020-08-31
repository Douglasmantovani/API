using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using LojaDeGames.Domains;
using LojaDeGames.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeGames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        CarrinhoRepository _u { get; set; }

        public CarrinhoController()
        {
            _u = new CarrinhoRepository();
        }

        [HttpPut("{idjogo}")]//idJogo
        public IActionResult adcionarJogoCarrinho(int idjogo)
        {
            try
            {
                var usr = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                if (_u.BuscarJogo(idjogo))
                {
                    if (_u.VerificarSeJogoFoiAdicionado(usr, idjogo))
                    {
                        if (_u.adcionarJogoCarrinho(idjogo, usr))
                        {
                            return Ok("Jogo adicionado ao seu carrinho");
                        }
                        else
                        {
                            return BadRequest("Seu carrinho esta lotado");
                        }
                    }
                    else
                    {
                        return BadRequest("Este jogo ja esta no seu carrinho");
                    }
                }
                else
                {
                    return BadRequest("Jogo indisponivel ou nao existe");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Nao foi possivel adicionar o item ao seu carrinho");
            }
        }

        [HttpPut("Remover/{id}")]//idJogo
        public IActionResult RemoverJogoCarrinho(int id)
        {
            try
            {
                var usr = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                if (_u.BuscarJogo(id))
                {
                    if (_u.RemoverJogoCarrinho(id, usr))
                    {
                        return Ok("Jogo removido do seu carrinho");
                    }
                    else
                    {
                        return BadRequest("Seu carrinho esta Vazio");
                    }
                }
                else
                {
                    return BadRequest("Jogo indisponivel ou nao existe");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Nao foi possivel remover o item do carrinho");
            }
        }
    }
}
