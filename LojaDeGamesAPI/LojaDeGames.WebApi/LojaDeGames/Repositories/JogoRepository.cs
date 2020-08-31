using LojaDeGames.Contexts;
using LojaDeGames.Domains;
using LojaDeGames.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaDeGames.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        public bool Adcionar(Jogo JogoNovo)
        {
            using (LojaDeGamesContext ctx = new LojaDeGamesContext())
            {
                try
                {
                    if (JogoNovo.TituloJogo == null)
                    {
                        return false;
                    }

                    if (JogoNovo.Descricao == null)
                    {
                        return false;
                    }

                    if (JogoNovo.DataLan == null)
                    {
                        return false;
                    }

                    if (JogoNovo.Valor == 0)
                    {
                        return false;
                    }

                    if (JogoNovo.IdEstudioNavigation == null)
                    {
                        return false;
                    }

                    ctx.Add(JogoNovo);

                    ctx.SaveChanges();

                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool AtualizarPorId(int id, Jogo jogo)
        {
            using (LojaDeGamesContext ctx = new LojaDeGamesContext())
            {
                try
                {
                    Jogo JogoBuscado = ctx.Jogo.Find(id);

                    if (JogoBuscado == null)
                    {
                        return false;
                    }

                    if (jogo.Capa != null)
                    {
                        JogoBuscado.Capa = jogo.Capa;
                        ctx.Update(JogoBuscado);
                        ctx.SaveChanges();
                        return true;
                    }


                    if (jogo.Caminho != null)
                    {
                        JogoBuscado.Caminho = jogo.Caminho;
                        ctx.Update(JogoBuscado);
                        ctx.SaveChanges();
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool BuscarJogo(Jogo JogoNovo)
        {
            using (LojaDeGamesContext ctx = new LojaDeGamesContext())
            {
                try
                {
                    Jogo JogoBuscado = ctx.Jogo.FirstOrDefault(u => u.TituloJogo == JogoNovo.TituloJogo);

                    if (JogoBuscado == null)
                    {
                        return false;
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

        }

        public List<Jogo> ListarJogos()
        {
            using (LojaDeGamesContext ctx = new LojaDeGamesContext())
            {
                try
                {
                    return ctx.Jogo.ToList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}

