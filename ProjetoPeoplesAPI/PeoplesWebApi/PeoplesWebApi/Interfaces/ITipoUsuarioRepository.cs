using PeoplesWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeoplesWebApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TiposUsuario> ListarTodos();

        void Deletar(int id);

        void Atualizar(int id, TiposUsuario tiposUsuario);

        TiposUsuario BuscarPorID(int id);
    }
}
