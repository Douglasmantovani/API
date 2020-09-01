using System;
using System.Collections.Generic;

namespace Gufi.WebApi.Domains
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int IdTipoUsuario { get; set; }
        public string TituloTipoUsuario { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
