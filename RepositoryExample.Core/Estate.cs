using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RepositoryExample.Core
{
    public class Estate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }

        public virtual ICollection<Town> Towns { get; set; }
    }
}
