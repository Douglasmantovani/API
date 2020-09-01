using Gufi.WebApi.Contexts;
using Gufi.WebApi.Domains;
using Gufi.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gufi.WebApi.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        public bool Adicionar(TipoEvento TipoEventoNovo)
        {
            using (GufiContext ctx = new GufiContext())
            {
                try
                {
                    ctx.Add(TipoEventoNovo);

                    ctx.SaveChanges();

                    return true; ;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool Atualizar(int id, TipoEvento TipoEvento)
        {
            using (GufiContext ctx = new GufiContext())
            {
                try
                {
                    TipoEvento TipoEventoBuscado = ctx.TipoEvento.Find(id);
                    if (TipoEventoBuscado == null)
                    {
                        return false;
                    }

                    else if (TipoEvento.TituloTipoEvento != TipoEventoBuscado.TituloTipoEvento)
                    {
                        TipoEventoBuscado.TituloTipoEvento = TipoEvento.TituloTipoEvento;
                    }

                    ctx.Update(TipoEventoBuscado);
                    ctx.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool Deletar(int id)
        {
            using (GufiContext ctx = new GufiContext())
            {
                try
                {
                    TipoEvento TipoEventoBuscado = ctx.TipoEvento.Find(id);
                    if (TipoEventoBuscado == null)
                    {
                        return false;
                    }
                    ctx.Remove(TipoEventoBuscado);
                    ctx.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public List<TipoEvento> ListarTipoEvento()
        {
            using (GufiContext ctx = new GufiContext())
            {
                try
                {
                    return ctx.TipoEvento.ToList();
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}

