using System;
using System.Collections.Generic;

namespace Gufi.WebApi.Domains
{
    public partial class TipoEvento
    {
        public TipoEvento()
        {
            Evento = new HashSet<Evento>();
        }

        public int IdTipoEvento { get; set; }
        public string TituloTipoEvento { get; set; }

        public virtual ICollection<Evento> Evento { get; set; }
    }
}
