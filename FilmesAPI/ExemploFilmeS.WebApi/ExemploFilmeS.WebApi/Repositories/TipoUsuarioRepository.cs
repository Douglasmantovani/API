using ExemploFilmeS.WebApi.Contexts;
using ExemploFilmeS.WebApi.Domains;
using ExemploFilmeS.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploFilmeS.WebApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        public bool Atualizar(int id,TipoUsuario tipoUsuario)
        {
            using (FilmesContext ctx = new FilmesContext())
            {
                try
                {
                    TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuario.Find(id);
                    if (tipoUsuarioBuscado == null)
                        return false;

                    else if (tipoUsuario != null)
                    {
                        tipoUsuarioBuscado.NomeTipoUsuario = tipoUsuario.NomeTipoUsuario;
                        ctx.Update(tipoUsuarioBuscado);
                        ctx.SaveChanges();
                        return true;
                    }
                    return false;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public bool Adicionar(TipoUsuario TipoUsuario)
        {
            using(FilmesContext ctx=new FilmesContext())
            {
                try
                {
                    if (TipoUsuario.NomeTipoUsuario != null && TipoUsuario.NomeTipoUsuario.Length >= 3)
                    {
                        ctx.Add(TipoUsuario);
                        ctx.SaveChanges();
                        return true;
                    }
                    return false;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public bool Deletar(int id)
        {
            using (FilmesContext ctx = new FilmesContext())
            {
                try
                {
                    TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuario.Find(id);
                    if (tipoUsuarioBuscado == null)
                        return false;
                    else if (tipoUsuarioBuscado != null)
                    {
                        ctx.Remove(tipoUsuarioBuscado);
                        ctx.SaveChanges();
                        return true;
                    }
                    return false;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public List<TipoUsuario> ListarTipoUsuarios()
        {
            using (FilmesContext ctx = new FilmesContext())
            {
                try
                {
                    return ctx.TipoUsuario.ToList();
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
    }
}
