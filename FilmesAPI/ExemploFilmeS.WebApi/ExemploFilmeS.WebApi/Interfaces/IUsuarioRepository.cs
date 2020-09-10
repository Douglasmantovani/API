using ExemploFilmeS.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploFilmeS.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> ListarUsuarios();
        bool Cadastrar(Usuario usuario);
        bool Deletar(int id);
        bool Atualizar(int id,Usuario usuario);

        Usuario Login(String Email, string Senha);
    }
}
