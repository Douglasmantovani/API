using System;
using System.Collections.Generic;

namespace ExemploFilmeS.WebApi.Domains
{
    public partial class Filme
    {
        public int IdFilme { get; set; }
        public string NomeFilme { get; set; }
        public DateTime DataLancamento { get; set; }
        public string Diretor { get; set; }
        public int IdGenero { get; set; }

        public virtual Genero IdGeneroNavigation { get; set; }
    }
}
