using LojaDeGames.Contexts;
using LojaDeGames.Domains;
using LojaDeGames.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaDeGames.Repositories
{
    public class CompraRepository : ICompraRepository
    {
        public bool AdcionarCompra(int id)
        {
            using (LojaDeGamesContext ctx = new LojaDeGamesContext())
            {
                try
                {
                    Usuario usuarioBuscado = ctx.Usuario.Find(id);
                    Carrinho carrinhoBuscado = ctx.Carrinho.Include(u => u.IdJogoNavigation).Include(u => u.IdJogo2Navigation)
                    .Include(u => u.IdJogo3Navigation).FirstOrDefault(u => u.IdCarrinho == usuarioBuscado.IdUsuario);
                    if (usuarioBuscado == null && carrinhoBuscado == null)
                    {
                        return false;
                    }
                    Compra compra = new Compra();
                    compra.IdUsuarioNavigation = usuarioBuscado;
                    compra.IdJogoNavigation = carrinhoBuscado.IdJogoNavigation;
                    compra.IdJogo2Navigation = carrinhoBuscado.IdJogo2Navigation;
                    compra.IdJogo3Navigation = carrinhoBuscado.IdJogo3Navigation;
                    compra.Valor = carrinhoBuscado.ValorContido;
                    compra.DataCompra = DateTime.Now;
                    ctx.Add(compra);
                    ctx.SaveChanges();
                    if (LimparCarrinho(carrinhoBuscado))
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
        public List<Compra> ListarCompras()
        {
            using (LojaDeGamesContext ctx = new LojaDeGamesContext())
            {
                try
                {
                    return ctx.Compra.Include(u => u.IdJogo2Navigation).Include(u => u.IdJogoNavigation)
                    .Include(u => u.IdJogo3Navigation).Include(u => u.IdUsuarioNavigation).ToList();
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
        public bool LimparCarrinho(Carrinho carrinho)
        {
            using (LojaDeGamesContext ctx = new LojaDeGamesContext())
            {
                try
                {
                    Carrinho carrinhoBuscado = ctx.Carrinho.FirstOrDefault(u => u.IdCarrinho == carrinho.IdCarrinho);
                    if (carrinhoBuscado == null)
                    {
                        return false;
                    }
                    else
                    {
                        carrinhoBuscado.IdJogo = null;
                        carrinhoBuscado.IdJogo2 = null;
                        carrinhoBuscado.IdJogo3 = null;
                        carrinhoBuscado.ValorContido = 0;
                        ctx.Update(carrinhoBuscado);
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
    }
}
