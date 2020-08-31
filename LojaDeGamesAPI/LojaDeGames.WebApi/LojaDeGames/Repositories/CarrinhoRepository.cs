using LojaDeGames.Contexts;
using LojaDeGames.Domains;
using LojaDeGames.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaDeGames.Repositories
{
    public class CarrinhoRepository : ICarrinhoRepository
    {
        public bool VerificarSeJogoFoiAdicionado(int idUsuario,int idJogo)
        {
            using (LojaDeGamesContext ctx = new LojaDeGamesContext())
            {
                try
                {
                    Jogo jogoAchado = ctx.Jogo.Find(idJogo);
                    Usuario usuarioLogado = ctx.Usuario.FirstOrDefault(u => u.IdUsuario == idUsuario);
                    Carrinho carrinho = ctx.Carrinho.FirstOrDefault(u => u.IdCarrinho == usuarioLogado.IdUsuario);

                    if (carrinho.IdJogoNavigation == jogoAchado)
                    {
                        return false;
                    }
                    else if(carrinho.IdJogo2Navigation == jogoAchado)
                    {
                        return false;
                    }
                    else if(carrinho.IdJogo3Navigation == jogoAchado)
                    {
                        return false;
                    }
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public bool adcionarJogoCarrinho(int idJogo, int idUsuario)
        {
            using (LojaDeGamesContext ctx = new LojaDeGamesContext())
            {
                try
                {
                    Jogo jogoAchado = ctx.Jogo.Find(idJogo);
                    Usuario usuarioLogado = ctx.Usuario.FirstOrDefault(u => u.IdUsuario == idUsuario);
                    Carrinho carrinho = ctx.Carrinho.FirstOrDefault(u => u.IdCarrinho == usuarioLogado.IdUsuario);

                    if (jogoAchado != null && carrinho.IdJogo == null)
                    {
                        carrinho.IdJogo = jogoAchado.IdJogo;
                        carrinho.ValorContido = carrinho.ValorContido + jogoAchado.Valor;
                        ctx.Update(carrinho);
                        ctx.SaveChanges();
                        return true;
                    }

                    if (jogoAchado != null && carrinho.IdJogo2 == null)
                    {
                        carrinho.IdJogo2 = jogoAchado.IdJogo;
                        carrinho.ValorContido = carrinho.ValorContido + jogoAchado.Valor;
                        ctx.Update(carrinho);
                        ctx.SaveChanges();
                        return true;
                    }

                    if (jogoAchado != null && carrinho.IdJogo3 == null)
                    {
                        carrinho.IdJogo3 = jogoAchado.IdJogo;
                        carrinho.ValorContido = carrinho.ValorContido + jogoAchado.Valor;
                        ctx.Update(carrinho);
                        ctx.SaveChanges();
                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public List<Carrinho> ListarCarrinho()
        {
            using (LojaDeGamesContext ctx = new LojaDeGamesContext())
            {
                try
                {
                    return ctx.Carrinho.ToList();
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public bool RemoverJogoCarrinho(int id, int idUsuario)
        {
            using (LojaDeGamesContext ctx = new LojaDeGamesContext())
            {
                try
                {
                    Carrinho carrinhoAchado = ctx.Carrinho.FirstOrDefault(u => u.IdCarrinho == idUsuario);
                    Jogo jogoAchado = ctx.Jogo.FirstOrDefault(u => u.IdJogo == id);

                    if (carrinhoAchado.IdJogo == null && carrinhoAchado.IdJogo2 == null && carrinhoAchado.IdJogo3 == null)
                    {
                        return false;
                    }
                    else if (carrinhoAchado.IdJogo == id)
                    {
                        carrinhoAchado.ValorContido = carrinhoAchado.ValorContido - jogoAchado.Valor;
                        carrinhoAchado.IdJogo = null;
                        ctx.Update(carrinhoAchado);
                        ctx.SaveChanges();
                        return true;
                    }

                    else if (carrinhoAchado.IdJogo2 == id)
                    {
                        carrinhoAchado.ValorContido = carrinhoAchado.ValorContido - jogoAchado.Valor;
                        carrinhoAchado.IdJogo2 = null;
                        ctx.Update(carrinhoAchado);
                        ctx.SaveChanges();
                        return true;
                    }
                    else if (carrinhoAchado.IdJogo3 == id)
                    {
                        carrinhoAchado.ValorContido = carrinhoAchado.ValorContido - jogoAchado.Valor;
                        carrinhoAchado.IdJogo3 = null;
                        ctx.Update(carrinhoAchado);
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
        public bool BuscarJogo(int id)
        {
            using(LojaDeGamesContext ctx = new LojaDeGamesContext())
            {
                try
                {
                    Jogo jogoBuscado = ctx.Jogo.Find(id);

                    if (jogoBuscado == null)
                    {
                        return false;
                    }

                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
    }
}
