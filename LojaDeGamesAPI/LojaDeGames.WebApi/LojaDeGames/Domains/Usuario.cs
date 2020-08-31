using System;
using System.Collections.Generic;

namespace LojaDeGames.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Compra = new HashSet<Compra>();
        }

        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public int? IdCarrinho { get; set; }
        public int IdTipoUsuario { get; set; }

        public virtual Carrinho IdCarrinhoNavigation { get; set; }
        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Compra> Compra { get; set; }
    }
}
