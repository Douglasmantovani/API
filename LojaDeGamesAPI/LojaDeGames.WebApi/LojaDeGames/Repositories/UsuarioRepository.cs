using LojaDeGames.Contexts;
using LojaDeGames.Domains;
using LojaDeGames.Interfaces;
using LojaDeGames.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaDeGames.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public void Atualizar(int id, Usuario usuario)
        {
            using (LojaDeGamesContext ctx = new LojaDeGamesContext())
            {
                Usuario usuarioBuscado = ctx.Usuario.Find(id);

                if (usuario.Nome != null)
                {
                    usuarioBuscado.Nome = usuario.Nome;
                }

                //if (usuario.Email != null)
                //{
                //    usuarioBuscado.Email = usuario.Email;
                //}

                if (usuario.Senha != null)
                {
                    usuarioBuscado.Senha = usuario.Senha;
                }

                if (usuario.Telefone != null)
                {
                    usuarioBuscado.Telefone = usuario.Telefone;
                }

                ctx.Update(usuarioBuscado);

                ctx.SaveChanges();
            }
        }

        public bool BuscarPorEmail(string email)
        {
            using (LojaDeGamesContext ctx = new LojaDeGamesContext())
            {
                try
                {
                    Usuario usuario = ctx.Usuario.FirstOrDefault(u => u.Email == email);

                    if (usuario == null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public Usuario BuscarPorid(int id)
        {
            using (LojaDeGamesContext ctx = new LojaDeGamesContext())
            {
                try
                {
                    Usuario usuarioBuscado = ctx.Usuario.Find(id);
                    return usuarioBuscado;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public bool Cadastrar(string nome, string email, string senha, string telefone)
        {
            using (LojaDeGamesContext ctx = new LojaDeGamesContext())
            {
                try
                {
                    Usuario usuarioNovo = new Usuario()
                    {
                        Nome = nome,
                        Email = email,
                        Senha = senha,
                        Telefone = telefone,
                        IdTipoUsuario = 2,
                    };

                    Carrinho carrinho = new Carrinho();

                    usuarioNovo.IdCarrinhoNavigation = carrinho;

                    ctx.Add(usuarioNovo);

                    ctx.SaveChanges();

                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public void Deletar(int id)
        {
            using (LojaDeGamesContext ctx = new LojaDeGamesContext())
            {

                Usuario usuarioBuscado = ctx.Usuario.Find(id);

                ctx.Remove(usuarioBuscado);

                ctx.SaveChanges();
            }
        }

        public List<Usuario> ListarUsuario(int id)
        {
            using (LojaDeGamesContext ctx = new LojaDeGamesContext())
            {
                return ctx.Usuario.Include(u => u.IdCarrinhoNavigation.IdJogoNavigation)
                 .Include(u => u.IdCarrinhoNavigation.IdJogo2Navigation)
                 .Include(u => u.IdCarrinhoNavigation.IdJogo3Navigation)
                 .Include(u => u.IdTipoUsuarioNavigation).Where(u => u.IdUsuario == id).ToList();
            }
        }

        public Usuario Login(LoginViewModel Usuario)
        {
            using (LojaDeGamesContext ctx = new LojaDeGamesContext())
            {
                try
                {
                    Usuario usuarioAchado = ctx.Usuario.FirstOrDefault(U => U.Email == Usuario.Email && U.Senha == Usuario.Senha);

                    if (usuarioAchado == null)
                    {
                        return null;
                    }
                    return usuarioAchado;

                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public List<Jogo> Meucarrinho(int id)
        {
            using (LojaDeGamesContext ctx = new LojaDeGamesContext())
            {
                try
                {
                    Usuario usuarioBuscado = ctx.Usuario.Include(u => u.IdCarrinhoNavigation).FirstOrDefault(u => u.IdUsuario == id);
                    Carrinho carrinho = ctx.Carrinho.FirstOrDefault(u => u.IdCarrinho == usuarioBuscado.IdCarrinho);
                    List<Jogo> jogos = new List<Jogo>();
                    Jogo jogo = ctx.Jogo.Find(carrinho.IdJogo);
                    Jogo jogo2 = ctx.Jogo.Find(carrinho.IdJogo2);
                    Jogo jogo3 = ctx.Jogo.Find(carrinho.IdJogo3);
                    jogos.Add(jogo);
                    jogos.Add(jogo2);
                    jogos.Add(jogo3);
                    return jogos;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
        public Perfil Perfil(int id)
        {
            using (LojaDeGamesContext ctx = new LojaDeGamesContext())
            {
                Usuario usuarioBuscado = ctx.Usuario.Find(id);

                Perfil perfil = new Perfil()
                {
                    Email = usuarioBuscado.Email,
                    Senha = usuarioBuscado.Senha,
                    Telefone = usuarioBuscado.Telefone,
                    Nome = usuarioBuscado.Nome
                };
                return perfil;
            }
        }
    }
}
