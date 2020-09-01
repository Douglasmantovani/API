using Gufi.WebApi.Contexts;
using Gufi.WebApi.Domains;
using Gufi.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gufi.WebApi.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        public bool Adicionar(Evento eventoNovo)
        {
            using(GufiContext ctx=new GufiContext())
            {
                try
                {
                    ctx.Add(eventoNovo);

                    ctx.SaveChanges();

                    return true; ;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool Atualizar(int id,Evento evento)
        {
            using (GufiContext ctx = new GufiContext())
            {
                try
                {
                    Evento eventoBuscado = ctx.Evento.Find(id);
                    if (eventoBuscado == null)
                    {
                        return false;
                    }

                    else if (evento.NomeEvento != eventoBuscado.NomeEvento)
                    {
                        eventoBuscado.NomeEvento = evento.NomeEvento;
                    }

                    else if (evento.DataEvento != eventoBuscado.DataEvento)
                    {
                        eventoBuscado.DataEvento = evento.DataEvento;
                    }

                    else if (evento.Descricao != eventoBuscado.Descricao)
                    {
                        eventoBuscado.Descricao = evento.Descricao;
                    }

                    else if (evento.AcessoLivre != eventoBuscado.AcessoLivre)
                    {
                        eventoBuscado.AcessoLivre = evento.AcessoLivre;
                    }

                    else if (evento.IdInstituicao != eventoBuscado.IdInstituicao)
                    {
                        eventoBuscado.IdInstituicao = evento.IdInstituicao;
                    }

                    else if (evento.IdTipoEvento != eventoBuscado.IdTipoEvento)
                    {
                        eventoBuscado.IdTipoEvento = evento.IdTipoEvento;
                    }

                    ctx.Update(eventoBuscado);
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
                    Evento eventoBuscado = ctx.Evento.Find(id);
                    if (eventoBuscado == null)
                    {
                        return false;
                    }
                    ctx.Remove(eventoBuscado);
                    ctx.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public List<Evento> ListarEvento()
        {
            using (GufiContext ctx = new GufiContext())
            {
                try
                {
                    return ctx.Evento.ToList();
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
