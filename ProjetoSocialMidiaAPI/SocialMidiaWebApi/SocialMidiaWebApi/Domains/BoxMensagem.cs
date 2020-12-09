using System;
using System.Collections.Generic;

namespace SocialMidiaWebApi.Domains
{
    public partial class BoxMensagem
    {
        public BoxMensagem()
        {
            Mensagem = new HashSet<Mensagem>();
            Usuario = new HashSet<Usuario>();
        }

        public int IdBoxMensagem { get; set; }

        public virtual ICollection<Mensagem> Mensagem { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
