using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WSTower.ViewModel
{
    public class LoginViewModel
    {
        public string Email { get; set; }

        public string Apelido { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        public string Senha { get; set; }
    }
}
