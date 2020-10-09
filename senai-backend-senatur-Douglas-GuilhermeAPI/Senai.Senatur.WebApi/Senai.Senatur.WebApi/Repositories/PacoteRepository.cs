using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    

    public class PacoteRepository : IPacoteRepository
    {
        SenaturContext ctx = new SenaturContext();


        
        public List<Pacote> Listar()
        {
            return ctx.Pacote.ToList();

        }

        public void Cadastrar(Pacote NovoPacote)
        {
            ctx.Pacote.Add(NovoPacote);

            ctx.SaveChanges();
        }

        public void AtualizarPorid(int id,Pacote PacoteAtualizado)
        {
            Pacote PacoteBuscado = ctx.Pacote.Find(id);

            if(PacoteAtualizado.NomePacote != null)
            {
                PacoteBuscado.NomePacote = PacoteAtualizado.NomePacote;
            }
            if (PacoteAtualizado.Descricao != null)
            {
                PacoteBuscado.Descricao = PacoteAtualizado.Descricao;
            }
            if (PacoteAtualizado.Dataida != null)
            {
                PacoteBuscado.Dataida = PacoteAtualizado.Dataida;
            }
            if (PacoteAtualizado.Datavolta != null)
            {
                PacoteBuscado.Datavolta = PacoteAtualizado.Datavolta;
            }
            if (PacoteAtualizado.Valor != 0)
            {
                PacoteBuscado.Valor = PacoteAtualizado.Valor;
            }
            if (PacoteAtualizado.Cidade != null)
            {
                PacoteBuscado.Cidade = PacoteAtualizado.Cidade;
            }
            if (PacoteAtualizado.Ativo == true || PacoteAtualizado.Ativo == false)
            {
                PacoteBuscado.Ativo = PacoteAtualizado.Ativo;
            }

            ctx.Pacote.Update(PacoteBuscado);

            ctx.SaveChanges();

        }

        public Pacote BuscarPorid(int id)
        {
            return ctx.Pacote.Find(id);

        }

        public List<Pacote> BuscarPorAtivo()
        {
            return ctx.Pacote.ToList().FindAll(p => p.Ativo == true);
        }

        public List<Pacote> BuscarPorInativo()
        {
            return ctx.Pacote.ToList().FindAll(p => p.Ativo == false);
        }

        public List<Pacote> BuscarPrecoCrescente()
        {
            return ctx.Pacote.OrderBy(p => p.Valor).ToList();
        }

        public List<Pacote> BuscarPeloNome(string nomeCidade)
        {
            return ctx.Pacote.Where(p => p.Cidade == nomeCidade).ToList();
        }

        public List<Pacote> BuscarPrecoDecrescente()
        {
            return ctx.Pacote.OrderByDescending(p => p.Valor).ToList();
        }
    }
}
