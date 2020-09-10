using ExemploFilmeS.WebApi.Contexts;
using ExemploFilmeS.WebApi.Domains;
using ExemploFilmeS.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploGeneroS.WebApi.Repositories
{
    public class GeneroRepository:IGeneroRepository
    {
        public bool Atualizar(int id, Genero Genero)
        {
            using (FilmesContext ctx = new FilmesContext())
            {
                try
                {
                    Genero GeneroBuscado = ctx.Genero.Find(id);
                    if (GeneroBuscado == null)
                        return false;

                    else if (Genero != null)
                    {
                        GeneroBuscado.NomeGenero = Genero.NomeGenero;
                        ctx.Update(GeneroBuscado);
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

        public bool Adicionar(Genero Genero)
        {
            using (FilmesContext ctx = new FilmesContext())
            {
                try
                {
                    if (Genero.NomeGenero != null)
                    {
                        ctx.Add(Genero);
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
                    Genero GeneroBuscado = ctx.Genero.Find(id);
                    if (GeneroBuscado == null)
                        return false;
                    else if (GeneroBuscado != null)
                    {
                        ctx.Remove(GeneroBuscado);
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

        public List<Genero> ListarGeneros()
        {
            using (FilmesContext ctx = new FilmesContext())
            {
                try
                {
                    List<Genero>list= ctx.Genero.ToList();
                    return list;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
    }
}
