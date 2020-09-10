using System;
using System.Collections.Generic;

namespace ExemploFilmeS.WebApi.Domains
{
    public partial class Genero
    {
        public Genero()
        {
            Filme = new HashSet<Filme>();
        }

        public int IdGenero { get; set; }
        public string NomeGenero { get; set; }

        public virtual ICollection<Filme> Filme { get; set; }
    }
}
