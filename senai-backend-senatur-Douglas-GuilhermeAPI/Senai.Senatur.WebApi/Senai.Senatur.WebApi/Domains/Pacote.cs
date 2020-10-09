using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Senatur.WebApi.Domains
{
    public partial class Pacote
    {
        public int IdUsuario { get; set; }
       
        public string NomePacote { get; set; }
        
        public string Descricao { get; set; }
        
        public DateTime Dataida { get; set; }
       
        public DateTime Datavolta { get; set; }
        
        public decimal Valor { get; set; }
        
        public string Cidade { get; set; }
        public bool? Ativo { get; set; }
    }
}
