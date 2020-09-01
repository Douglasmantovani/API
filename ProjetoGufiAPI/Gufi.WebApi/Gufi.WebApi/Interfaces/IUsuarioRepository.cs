using Gufi.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gufi.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> ListarUsuario();
        bool Adicionar(Usuario usuarioNovo);
        bool Alterar(int id, Usuario usuarioNovo);
        bool Deletar(int id);
        Usuario Login(string nomeUsuario, string Email, string Senha);
    }
}
