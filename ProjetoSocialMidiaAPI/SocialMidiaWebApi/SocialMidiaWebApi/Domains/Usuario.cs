using System;
using System.Collections.Generic;

namespace SocialMidiaWebApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Mensagem = new HashSet<Mensagem>();
        }

        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string NomeUsuario { get; set; }
        public int? IdTipoUsuario { get; set; }
        public int? IdBoxMensagem { get; set; }

        public virtual BoxMensagem IdBoxMensagemNavigation { get; set; }
        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Mensagem> Mensagem { get; set; }
    }
}
