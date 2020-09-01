using Gufi.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gufi.WebApi.Interfaces
{
    interface ITipoEventoRepository
    {
        List<TipoEvento> ListarTipoEvento();
        bool Adicionar(TipoEvento tipoEventoNovo);
        bool Deletar(int id);
        bool Atualizar(int id,TipoEvento tipoEvento);
    }
}
