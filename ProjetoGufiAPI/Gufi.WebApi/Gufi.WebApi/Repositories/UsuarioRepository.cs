using Gufi.WebApi.Contexts;
using Gufi.WebApi.Domains;
using Gufi.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gufi.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public bool Adicionar(Usuario UsuarioNovo)
        {
            using (GufiContext ctx = new GufiContext())
            {
                try
                {
                    UsuarioNovo.IdTipoUsuario = 2;
                    ctx.Add(UsuarioNovo);

                    ctx.SaveChanges();

                    return true; ;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool Alterar(int id, Usuario UsuarioAtualizado)
        {
            using (GufiContext ctx = new GufiContext())
            {
                try
                {
                    Usuario usuarioBuscado = ctx.Usuario.Find(id);
                    if (usuarioBuscado == null)
                    {
                        return false;
                    }

                    if (UsuarioAtualizado.Email != null)
                    {
                        usuarioBuscado.Email = UsuarioAtualizado.Email;
                    }

                    if (UsuarioAtualizado.Senha != null)
                    {
                        usuarioBuscado.Senha = UsuarioAtualizado.Senha;
                    }
                    if (UsuarioAtualizado.NomeUsuario != null)
                    {
                        usuarioBuscado.NomeUsuario = UsuarioAtualizado.NomeUsuario;
                    }
                    if (UsuarioAtualizado.Genero != null)
                    {
                        usuarioBuscado.Genero = UsuarioAtualizado.Genero;
                    }

                    ctx.Update(usuarioBuscado);
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
                    Usuario UsuarioBuscado = ctx.Usuario.Find(id);
                    if (UsuarioBuscado == null)
                    {
                        return false;
                    }
                    ctx.Remove(UsuarioBuscado);
                    ctx.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public List<Usuario> ListarUsuario()
        {
            using (GufiContext ctx = new GufiContext())
            {
                try
                {
                    return ctx.Usuario.ToList();
                }
                catch
                {
                    return null;
                }
            }
        }
        public Usuario Login(string nomeUsuario, string Email, string Senha)
        {
            using (GufiContext ctx=new GufiContext())
            {
                try
                {
                    Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.Email == Email && u.Senha == Senha);
                    if (usuarioBuscado == null)
                    {
                        Usuario usuarioBuscadoNome = ctx.Usuario.FirstOrDefault(u=>u.NomeUsuario==nomeUsuario&&u.Senha==Senha);
                        if (usuarioBuscadoNome == null)
                        {
                            return null;
                        }
                        else
                        {
                            return usuarioBuscadoNome;
                        }
                    }
                    return usuarioBuscado;
                }catch(Exception e)
                {
                    return null;
                }
            }
        }
        public bool VerificarSeUsuarioExiste(string email, string nome)
        {
            using(GufiContext ctx=new GufiContext())
            {
                try
                {
                    Usuario usuarioBuscadoEmail = ctx.Usuario.FirstOrDefault(u => u.Email == email);
                    if (usuarioBuscadoEmail == null)
                    {
                        Usuario usuarioBuscadoNome = ctx.Usuario.FirstOrDefault(u => u.NomeUsuario==nome);
                        if (usuarioBuscadoNome == null)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }catch(Exception e)
                {
                    return false;
                }
            }
        }
    }
}

