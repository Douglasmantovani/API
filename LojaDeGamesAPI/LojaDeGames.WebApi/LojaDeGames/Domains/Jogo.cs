using System;
using System.Collections.Generic;

namespace LojaDeGames.Domains
{
    public partial class Jogo
    {
        public Jogo()
        {
            CarrinhoIdJogo2Navigation = new HashSet<Carrinho>();
            CarrinhoIdJogo3Navigation = new HashSet<Carrinho>();
            CarrinhoIdJogoNavigation = new HashSet<Carrinho>();
            CompraIdJogo2Navigation = new HashSet<Compra>();
            CompraIdJogo3Navigation = new HashSet<Compra>();
            CompraIdJogoNavigation = new HashSet<Compra>();
        }

        public int IdJogo { get; set; }
        public string TituloJogo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLan { get; set; }
        public decimal Valor { get; set; }
        public byte[] Capa { get; set; }
        public bool? Promocao { get; set; }
        public int IdEstudio { get; set; }
        public string Caminho { get; set; }

        public virtual Estudio IdEstudioNavigation { get; set; }
        public virtual ICollection<Carrinho> CarrinhoIdJogo2Navigation { get; set; }
        public virtual ICollection<Carrinho> CarrinhoIdJogo3Navigation { get; set; }
        public virtual ICollection<Carrinho> CarrinhoIdJogoNavigation { get; set; }
        public virtual ICollection<Compra> CompraIdJogo2Navigation { get; set; }
        public virtual ICollection<Compra> CompraIdJogo3Navigation { get; set; }
        public virtual ICollection<Compra> CompraIdJogoNavigation { get; set; }
    }
}
