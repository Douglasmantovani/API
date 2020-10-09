using System;
using System.Collections.Generic;

namespace Senai.Senatur.WebApi.Domains
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? IdTipousuario { get; set; }

        public TipoUsuario IdTipousuarioNavigation { get; set; }
    }
}
