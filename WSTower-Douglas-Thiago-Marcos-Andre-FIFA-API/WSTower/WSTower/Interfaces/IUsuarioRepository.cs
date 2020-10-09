using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTower.Domains;
using WSTower.ViewModel;

namespace WSTower.Interfaces
{
    interface IUsuarioRepository
    {
        void Cadastar(Usuario usuario);

        List<Usuario> ListarTodos();

        Usuario Login(string email,string senha,string apelido);

        bool AlterarUsuario(int id, Usuario usuario);

        void AlterarSenha(int id,LoginViewModel login);

        bool BuscarPorEmail(string email);

        bool BuscarPorApelido(string apelido);
    }
}
