using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        Usuario BuscarPorEmailSenha(string email, string senha);

        void Cadastrar(Usuario usuario);

        void AtualizarPorid(int id, Usuario user);

        List<Usuario> ListarUsuarios();
    }
}
