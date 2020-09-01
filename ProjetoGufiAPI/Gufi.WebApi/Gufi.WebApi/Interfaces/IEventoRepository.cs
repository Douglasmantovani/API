using Gufi.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gufi.WebApi.Interfaces
{
    interface IEventoRepository
    {
        List<Evento> ListarEvento();
        bool Adicionar(Evento eventoNovo);
        bool Deletar(int id);
        bool Atualizar(int id,Evento evento);
    }
}
