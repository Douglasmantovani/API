using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeoplesWebApi.Domains;
using PeoplesWebApi.Repositories;

namespace PeoplesWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]


    public class FuncionariosController : ControllerBase
    {
          FuncionarioRepository _Funcionario { get; set; }

        public FuncionariosController()
        {
            _Funcionario = new FuncionarioRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_Funcionario.ListarTodods());
        }

        [HttpPost]
        public IActionResult Cadastrar(Funcionarios funcionarios)
        {
            _Funcionario.Cadastrar(funcionarios);

            return Ok("Funcionario cadastrado com sucesso");
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id,Funcionarios funcionarios)
        {
            _Funcionario.Atualizar(id, funcionarios);

            return Ok("Atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _Funcionario.Deletar(id);

            return Ok("Funcionario deletado");
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorID(int id)
        {
            return Ok(_Funcionario.BuscarPorID(id));
        }

        [HttpGet("BuscarPorNome/{nome}")]
        public IActionResult BuscarPorNome(string nome)
        {
           return Ok( _Funcionario.BuscarPorNome(nome));
        }  
    }
}