using Gufi.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gufi.WebApi.Interfaces
{
    interface IPresencaRepository
    {
        List<Presenca> Listar();
        List<Presenca> ListarMinhas(int id);        
        void AprovarRecusar(int id, string status);  
        void Convidar(Presenca convite);
        void Inscrever(Presenca inscricao);
    }
}
