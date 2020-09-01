using System;
using System.Collections.Generic;

namespace Gufi.WebApi.Domains
{
    public partial class Instituicao
    {
        public Instituicao()
        {
            Evento = new HashSet<Evento>();
        }

        public int IdInstituicao { get; set; }
        public string Cnpj { get; set; }
        public string NomeFantasia { get; set; }
        public string Endereco { get; set; }

        public virtual ICollection<Evento> Evento { get; set; }
    }
}
