using InlockGamesWebAPI.Domains;
using InlockGamesWebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InlockGamesWebAPI.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        InlockContext dbx = new InlockContext();

        public bool Adicionar(Estudio estudio)
        {
            dbx.Add(estudio);

            dbx.SaveChanges();

            return true;
        }

        public List<Estudio> ListarEstudio()
        {
            return dbx.Estudio.ToList();
        }

        public List<Estudio> ListarEstudioComJogo()
        {
            return dbx.Estudio.Include(u => u.Jogo).ToList();
        }
    }
}
