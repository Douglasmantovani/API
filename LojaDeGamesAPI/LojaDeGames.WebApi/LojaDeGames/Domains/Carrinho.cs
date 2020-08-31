using System;
using System.Collections.Generic;

namespace LojaDeGames.Domains
{
    public partial class Carrinho
    {
        public Carrinho()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int IdCarrinho { get; set; }
        public int? IdJogo { get; set; }
        public int? IdJogo2 { get; set; }
        public int? IdJogo3 { get; set; }
        public decimal? ValorContido { get; set; }

        public virtual Jogo IdJogo2Navigation { get; set; }
        public virtual Jogo IdJogo3Navigation { get; set; }
        public virtual Jogo IdJogoNavigation { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
