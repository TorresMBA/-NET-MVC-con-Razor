using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMVC.Models
{
    public class Paciente
    {
        [Key]
        public int IdPaciente { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Dirrecion { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }
    }
}
