using System;
using System.Collections.Generic;

namespace SocialMidiaWebApi.Domains
{
    public partial class Mensagem
    {
        public int IdMensagem { get; set; }
        public string Mensagem1 { get; set; }
        public DateTime? DataMensagem { get; set; }
        public int IdBoxMensagemDestino { get; set; }
        public int IdUsuario { get; set; }

        public virtual BoxMensagem IdBoxMensagemDestinoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
