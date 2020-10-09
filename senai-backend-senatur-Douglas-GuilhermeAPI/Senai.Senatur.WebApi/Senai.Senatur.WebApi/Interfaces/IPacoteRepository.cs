using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Interfaces
{
    interface IPacoteRepository
    {
        List<Pacote> Listar();

        void Cadastrar(Pacote pacote);

        void AtualizarPorid(int id,Pacote pacote);

        Pacote BuscarPorid(int id);

        List<Pacote> BuscarPorAtivo();

        List<Pacote> BuscarPorInativo();

        List<Pacote> BuscarPrecoCrescente();

        List<Pacote> BuscarPeloNome(string nomeCidade);

        List<Pacote> BuscarPrecoDecrescente();
    }
}
