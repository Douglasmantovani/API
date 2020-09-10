using ExemploFilmeS.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploFilmeS.WebApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuario> ListarTipoUsuarios();
        bool Adicionar(TipoUsuario TipoUsuario);
        bool Deletar(int id);
        bool Atualizar(int id,TipoUsuario tipoUsuario);
    }
}
