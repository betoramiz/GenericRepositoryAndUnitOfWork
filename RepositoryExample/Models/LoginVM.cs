using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RepositoryExample.Models
{
    public class LoginVM
    {
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name="Correo Electronico")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name="Contraseña")]
        public string Password { get; set; }
    }
}
