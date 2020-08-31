using System;
using System.Collections.Generic;

namespace LojaDeGames.Domains
{
    public partial class Compra
    {
        public int IdCompra { get; set; }
        public int IdUsuario { get; set; }
        public int IdJogo { get; set; }
        public int? IdJogo2 { get; set; }
        public int? IdJogo3 { get; set; }
        public string NomeTitular { get; set; }
        public string NumeroCartao { get; set; }
        public DateTime? Validade { get; set; }
        public string Cvv { get; set; }
        public decimal? Valor { get; set; }
        public DateTime DataCompra { get; set; }

        public virtual Jogo IdJogo2Navigation { get; set; }
        public virtual Jogo IdJogo3Navigation { get; set; }
        public virtual Jogo IdJogoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
