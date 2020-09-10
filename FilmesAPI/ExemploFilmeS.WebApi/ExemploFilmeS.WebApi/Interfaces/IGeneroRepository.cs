using ExemploFilmeS.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploFilmeS.WebApi.Interfaces
{
    interface IGeneroRepository
    {
        List<Genero> ListarGeneros();
        bool Adicionar(Genero Genero);
        bool Deletar(int id);
        bool Atualizar(int id,Genero genero);
    }
}
