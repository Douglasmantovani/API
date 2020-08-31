using LojaDeGames.Contexts;
using LojaDeGames.Domains;
using LojaDeGames.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaDeGames.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        public bool Adcionar(Estudio estudioNovo)
        {
            using (LojaDeGamesContext ctx = new LojaDeGamesContext())
            {
                try
                {
                    if (estudioNovo.NomeEstudio.Length < 4)
                    {
                        return false;
                    }

                    ctx.Estudio.Add(estudioNovo);

                    ctx.SaveChanges();

                    return true;
                }
                catch (Exception e)
                {
                    return true;
                }
            }
        }

        public bool BuscarEstudio(Estudio estudioNovo)
        {
            using (LojaDeGamesContext ctx = new LojaDeGamesContext())
            {
                try
                {
                    Estudio estudioBuscado = ctx.Estudio.FirstOrDefault(e => e.NomeEstudio == estudioNovo.NomeEstudio);

                    if (estudioBuscado == null)
                    {
                        return false;
                    }

                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public List<Estudio> ListarEstudios()
        {
            using (LojaDeGamesContext ctx = new LojaDeGamesContext())
            {
                try
                {
                    return ctx.Estudio.ToList();
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
    }
}
