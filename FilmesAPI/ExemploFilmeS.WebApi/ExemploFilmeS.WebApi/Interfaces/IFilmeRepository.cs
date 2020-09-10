using ExemploFilmeS.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploFilmeS.WebApi.Interfaces
{
    interface IFilmeRepository
    {
        List<Filme> ListarFilmes();
        bool Adicionar(Filme Filme);
        bool Deletar(int id);
        bool Atualizar(int id,Filme filme);
    }
}
