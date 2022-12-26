using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMVC.Models
{
    public class MedicoEspecialidad
    {
        public int IdMedico { get; set; }

        public int IdEspecialidad { get; set; }

        public Medico Medico { get; set; }

        public Especialidad Especialidad { get; set; }
    }
}
