using System;
using System.Collections.Generic;

namespace PeoplesWebApi.Domains
{
    public partial class Funcionarios
    {
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime? DataNascimento { get; set; }
    }
}
