using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using LojaDeGames.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeGames.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        CompraRepository _u { get; set; }

        public ComprasController()
        {
            _u = new CompraRepository();
        }
        public IActionResult ListarCompras()
        {
            return Ok(_u.ListarCompras());
        }

        [Authorize]
        [HttpPost]
        public IActionResult AdicionarCompra()
        {
            var usr = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
            if (_u.AdcionarCompra(usr))
            {
                return Ok("Compra realizada com sucesso");
            }
            return BadRequest("Nao foi possivel realizar a compra");
        }
    }
}
