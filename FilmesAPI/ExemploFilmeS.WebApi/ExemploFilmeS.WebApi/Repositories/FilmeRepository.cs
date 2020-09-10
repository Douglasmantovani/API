using ExemploFilmeS.WebApi.Contexts;
using ExemploFilmeS.WebApi.Domains;
using ExemploFilmeS.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploFilmeS.WebApi.Repository
{
    public class FilmeRepository:IFilmeRepository
    {
        public bool Atualizar(int id, Filme Filme)
        {
            using (FilmesContext ctx = new  FilmesContext())
            {
                try
                {
                    Filme FilmeBuscado = ctx.Filme.Find(id);
                    if (FilmeBuscado == null)
                        return false;

                    else if (Filme != null)
                    {
                        FilmeBuscado.NomeFilme = Filme.NomeFilme;
                        ctx.Update(FilmeBuscado);
                        ctx.SaveChangesAsync();
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

        public bool Adicionar(Filme Filme)
        {
            using (FilmesContext ctx = new FilmesContext())
            {
                try
                {
                    if (Filme.NomeFilme!=null||Filme.DataLancamento!=null|| Filme.Diretor!=null||Filme.IdGenero!=0)
                    {
                        ctx.Add(Filme);
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
                    Filme FilmeBuscado = ctx.Filme.Find(id);
                    if (FilmeBuscado == null)
                        return false;
                    else if (FilmeBuscado != null)
                    {
                        ctx.Remove(FilmeBuscado);
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

        public List<Filme> ListarFilmes()
        {
            using (FilmesContext ctx = new FilmesContext())
            {
                try
                {
                    return ctx.Filme.ToList();
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
    }
}
