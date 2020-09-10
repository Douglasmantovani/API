using ExemploFilmeS.WebApi.Contexts;
using ExemploFilmeS.WebApi.Domains;
using ExemploFilmeS.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploFilmeS.WebApi.Repository
{
    public class UsuarioRepository:IUsuarioRepository
    {
        public bool Atualizar(int id, Usuario Usuario)
        {
            using (FilmesContext ctx = new FilmesContext())
            {
                try
                {
                    Usuario UsuarioBuscado = ctx.Usuario.Find(id);
                    if (UsuarioBuscado == null)
                        return false;

                    else if (Usuario.Nome != null)
                    {
                        UsuarioBuscado.Nome = Usuario.Nome;
                    }

                    else if (Usuario.Email != null)
                    {
                        UsuarioBuscado.Email = Usuario.Email;
                    }

                    else if (Usuario.Senha != null)
                    {
                        UsuarioBuscado.Senha = Usuario.Senha;
                    }
                    return false;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public bool Cadastrar(Usuario Usuario)
        {
            using (FilmesContext ctx = new FilmesContext())
            {
                try
                {
                    if (Usuario.Nome == null|| Usuario.Email == null || Usuario.Senha == null)
                    {
                        return false;
                    }
                    else
                    {
                        Usuario.IdTipoUsuario = 2;
                        ctx.Add(Usuario);
                        ctx.SaveChanges();
                        return true;
                    }
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
                    Usuario UsuarioBuscado = ctx.Usuario.Find(id);
                    if (UsuarioBuscado == null)
                        return false;
                    else if (UsuarioBuscado != null)
                    {
                        ctx.Remove(UsuarioBuscado);
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

        public List<Usuario> ListarUsuarios()
        {
            using (FilmesContext ctx = new FilmesContext())
            {
                try
                {
                    return ctx.Usuario.ToList();
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public Usuario Login(string Email, string Senha)
        {
            using (FilmesContext ctx = new FilmesContext())
            {
                try
                {
                    Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.Email == Email && u.Senha == Senha);
                    if (usuarioBuscado == null)
                        return null;

                    return usuarioBuscado;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
    }
}

