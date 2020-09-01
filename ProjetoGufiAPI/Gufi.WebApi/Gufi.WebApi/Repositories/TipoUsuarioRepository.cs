using Gufi.WebApi.Contexts;
using Gufi.WebApi.Domains;
using Gufi.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gufi.WebApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        public bool Adicionar(TipoUsuario TipoUsuarioNovo)
        {
            using (GufiContext ctx = new GufiContext())
            {
                try
                {
                    ctx.Add(TipoUsuarioNovo);

                    ctx.SaveChanges();

                    return true; ;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool Atualizar(int id, TipoUsuario TipoUsuario)
        {
            using (GufiContext ctx = new GufiContext())
            {
                try
                {
                    TipoUsuario TipoUsuarioBuscado = ctx.TipoUsuario.Find(id);
                    if (TipoUsuarioBuscado == null)
                    {
                        return false;
                    }

                    else if (TipoUsuario.TituloTipoUsuario != TipoUsuarioBuscado.TituloTipoUsuario)
                    {
                        TipoUsuarioBuscado.TituloTipoUsuario = TipoUsuario.TituloTipoUsuario;
                    }

                    ctx.Update(TipoUsuarioBuscado);
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
                    TipoUsuario TipoUsuarioBuscado = ctx.TipoUsuario.Find(id);
                    if (TipoUsuarioBuscado == null)
                    {
                        return false;
                    }
                    ctx.Remove(TipoUsuarioBuscado);
                    ctx.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public List<TipoUsuario> ListarTipoUsuario()
        {
            using (GufiContext ctx = new GufiContext())
            {
                try
                {
                    return ctx.TipoUsuario.ToList();
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}

