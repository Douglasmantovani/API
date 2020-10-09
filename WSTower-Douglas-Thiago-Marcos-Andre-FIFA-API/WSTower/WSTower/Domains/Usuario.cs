using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WSTower.Domains
{
    public partial class Usuario
    {
        public int Id { get; set; }

        [StringLength(30, MinimumLength = 3, ErrorMessage = "O nome conter no mínimo 3 e no máximo 30 caracteres")]
        public string Nome { get; set; }

        public string Email { get; set; }

        [StringLength(30, MinimumLength = 3, ErrorMessage = "O apelido deve conter no mínimo 3 e no máximo 30 caracteres")]
        public string Apelido { get; set; }

        public byte[] Foto { get; set; }

        [StringLength(30, MinimumLength = 3, ErrorMessage = "A senha deve conter no mínimo 3 e no máximo 30 caracteres")]
        public string Senha { get; set; }
    }
}
