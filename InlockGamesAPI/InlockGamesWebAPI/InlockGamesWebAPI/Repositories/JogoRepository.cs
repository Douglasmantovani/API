using InlockGamesWebAPI.Domains;
using InlockGamesWebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InlockGamesWebAPI.Repositories
{
    public class JogoRepository:IJogoRepository
    {
        InlockContext dbx = new InlockContext();

        public bool Adicionar(Jogo Jogo)
        {
            

            dbx.Add(Jogo);

            dbx.SaveChanges();

            return true;
        }

        public bool Atualizar(int id, Jogo JogoAtualizado)
        {
            Jogo JogoBuscado = dbx.Jogo.Find(id);

            if (JogoAtualizado.TituloJogo != null)
            {
                JogoBuscado.TituloJogo = JogoAtualizado.TituloJogo;
            }


            if (JogoAtualizado.Descricao != null)
            {
                JogoBuscado.Descricao = JogoAtualizado.Descricao;
            }

            if (JogoAtualizado.DataLan != null)
            {
                JogoBuscado.DataLan = JogoAtualizado.DataLan;
            }

            if (JogoAtualizado.Valor <= 0)
            {
                JogoBuscado.Valor = JogoAtualizado.Valor;
            }

            if (JogoAtualizado.IdEstudio != 0)
            {
                JogoBuscado.IdEstudio = JogoAtualizado.IdEstudio;
            }


            dbx.Update(JogoBuscado);

            dbx.SaveChanges();

            return true;
        }

        public bool Deletar(int id)
        {
            Jogo JogoBuscado = dbx.Jogo.Find(id);

            dbx.Remove(JogoBuscado);

            dbx.SaveChanges();

            return true;
        }

        public List<Jogo> ListarComEstudio()
        {
            return dbx.Jogo.Include(u=>u.IdEstudioNavigation).ToList();
        }

        public List<Jogo> ListarJogos()
        {
            return dbx.Jogo.ToList();
        }

    }
}
