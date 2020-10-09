using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTower.Domains;
using WSTower.Interfaces;

namespace WSTower.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        TowerContext dbx = new TowerContext();

        public void Atualizar(int id,Jogo jogoAtualizado)
        {
            Jogo JogoBuscado = dbx.Jogo.Find(id);

            if (jogoAtualizado.SelecaoCasa != null)
            {
                JogoBuscado.SelecaoCasa = jogoAtualizado.SelecaoCasa;
            }

            if (jogoAtualizado.SelecaoVisitante != null)
            {
                JogoBuscado.SelecaoVisitante = jogoAtualizado.SelecaoVisitante;
            }

            if (jogoAtualizado.PlacarCasa != null)
            {
                JogoBuscado.PlacarCasa = jogoAtualizado.PlacarCasa;
            }

            if (jogoAtualizado.PlacarVisitante > 0)
            {
                JogoBuscado.PlacarVisitante = jogoAtualizado.PlacarVisitante;
            }

            if (jogoAtualizado.PenaltisCasa > 0)
            {
                JogoBuscado.PenaltisCasa = jogoAtualizado.PenaltisCasa;
            }

            if (jogoAtualizado.Data != null)
            {
                JogoBuscado.Data = jogoAtualizado.Data;
            }

            if (jogoAtualizado.Estadio != null)
            {
                JogoBuscado.Estadio = jogoAtualizado.Estadio;
            }
            dbx.Update(JogoBuscado);

            dbx.SaveChanges();
        }

        public void CadastrarJogo(Jogo jogo)
        {
            dbx.Jogo.Add(jogo);

            dbx.SaveChanges();
        }

        public List<Selecao> ListarNomeSelecao(string NomeSelecao)
        {
            return dbx.Selecao.Where(u =>u.Nome==NomeSelecao).Include(u=>u.Jogador).ToList();
        }

        public List<Jogo> ListarPorData(string DataJogo)
        {
          
            return dbx.Jogo.Where(u => u.Data==DateTime.Parse(DataJogo)).ToList();
        }

        public List<Jogo> ListarPorEstadio(string NomeEstadio)
        {
            return dbx.Jogo.Where(u =>u.Estadio==NomeEstadio).ToList();
        }

        public List<Jogo> ListarTodosJogos()
        {
            return dbx.Jogo.Include(u => u.SelecaoCasaNavigation).Include(w=>w.SelecaoCasaNavigation.Jogador).Include(q=>q.SelecaoVisitanteNavigation).Include(i=>i.SelecaoVisitanteNavigation.Jogador).ToList();
        }
    }
}
