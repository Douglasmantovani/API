using PeoplesWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeoplesWebApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuarios> ListarTodosUsuarios();

        void Atualizar(int id, Usuarios usuarios);

        void Deletar(int id);

        void Cadastrar(Usuarios usuarios);

        Usuarios BuscarPorID(int id);
    }
}
