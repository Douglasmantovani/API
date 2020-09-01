using System;
using System.Collections.Generic;

namespace Gufi.WebApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Presenca = new HashSet<Presenca>();
        }

        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Genero { get; set; }
        public DateTime DataNascimento { get; set; }
        public int? IdTipoUsuario { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Presenca> Presenca { get; set; }
    }
}
