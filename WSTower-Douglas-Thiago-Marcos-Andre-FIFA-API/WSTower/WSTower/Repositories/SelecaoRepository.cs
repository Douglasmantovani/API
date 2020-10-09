using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTower.Domains;
using WSTower.Interfaces;

namespace WSTower.Repositories
{
    public class SelecaoRepository : ISelecaoRepository
    {
        Selecao selecao = new Selecao();
        TowerContext dbx = new TowerContext();

        public List<Selecao> ListarComJogador()
        {
            return dbx.Selecao.Include(s=>s.Jogador).ToList();
        }

        public List<Selecao> ListarConfrontos()
        {
            return dbx.Selecao.Include(s => s.JogoSelecaoCasaNavigation).Include(f=>f.JogoSelecaoVisitanteNavigation).Include(d=>d.Jogador).ToList();
        }

        public List<Selecao> ListarTodos()
        {
            return dbx.Selecao.ToList();
        }
    }
}
