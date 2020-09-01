using Gufi.WebApi.Contexts;
using Gufi.WebApi.Domains;
using Gufi.WebApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gufi.WebApi.Repositories
{
    public class PresencaRepository : IPresencaRepository
    {
        public void AprovarRecusar(int id, string status)
        {
            using (GufiContext ctx = new GufiContext())
            {
                try
                {
                    Presenca presencaBuscada = ctx.Presenca
                .Include(p => p.IdUsuarioNavigation)
                .Include(p => p.IdEventoNavigation)
                .FirstOrDefault(p => p.IdPresenca == id);

                    switch (status)
                    {
                        case "1":
                            presencaBuscada.Situacao = "Confirmada";
                            break;

                        case "0":
                            presencaBuscada.Situacao = "Recusada";
                            break;

                        case "2":
                            presencaBuscada.Situacao = "Não confirmada";
                            break;

                        default:
                            presencaBuscada.Situacao = presencaBuscada.Situacao;
                            break;
                    }

                    ctx.Presenca.Update(presencaBuscada);

                    ctx.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void Convidar(Presenca convite)
        {
            using (GufiContext ctx = new GufiContext())
            {
                try
                {
                    convite.Situacao = "Não confirmada";

                    ctx.Presenca.Add(convite);

                    ctx.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void Inscrever(Presenca inscricao)
        {
            using (GufiContext ctx = new GufiContext())
            {
                try
                {
                    inscricao.Situacao = "Não confirmada";

                    ctx.Presenca.Add(inscricao);

                    ctx.SaveChanges();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public List<Presenca> Listar()
        {
            using (GufiContext ctx = new GufiContext())
            {
                try
                {
                    return ctx.Presenca
                .Include(p => p.IdUsuarioNavigation)
                .Include(p => p.IdEventoNavigation)
                .Include(p => p.IdEventoNavigation.IdTipoEventoNavigation)
                .Include(p => p.IdEventoNavigation.IdInstituicaoNavigation)
                .ToList();
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public List<Presenca> ListarMinhas(int id)
        {
            using (GufiContext ctx = new GufiContext())
            {
                try
                {
                    return ctx.Presenca
               .Include(p => p.IdEventoNavigation)
               .Include(p => p.IdEventoNavigation.IdTipoEventoNavigation)
               .Include(p => p.IdEventoNavigation.IdInstituicaoNavigation)
               .Where(p => p.IdUsuario == id)
               .ToList();
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
    }
}