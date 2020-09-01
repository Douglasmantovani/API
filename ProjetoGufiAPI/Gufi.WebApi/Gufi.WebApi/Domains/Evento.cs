using System;
using System.Collections.Generic;

namespace Gufi.WebApi.Domains
{
    public partial class Evento
    {
        public Evento()
        {
            Presenca = new HashSet<Presenca>();
        }

        public int IdEvento { get; set; }
        public string NomeEvento { get; set; }
        public DateTime DataEvento { get; set; }
        public string Descricao { get; set; }
        public bool? AcessoLivre { get; set; }
        public int? IdInstituicao { get; set; }
        public int? IdTipoEvento { get; set; }

        public virtual Instituicao IdInstituicaoNavigation { get; set; }
        public virtual TipoEvento IdTipoEventoNavigation { get; set; }
        public virtual ICollection<Presenca> Presenca { get; set; }
    }
}
