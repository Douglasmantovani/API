using Gufi.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gufi.WebApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuario> ListarTipoUsuario();
        bool Adicionar(TipoUsuario tipoUsuario);
        bool Deletar(int id);
        bool Atualizar(int id,TipoUsuario tipoUsuario);
    }
}
