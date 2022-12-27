using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMVC.Models
{
    public class Turno
    {
        [Key]
        public int IdTurno { get; set; }

        public int IdPaciente { get; set; }

        public int IdMedico { get; set; }

        [Display(Name = "Fecha hora ini.")]
        public DateTime FechaHoraInicio { get; set; }

        [Display(Name = "Fecha hora fin")]
        public DateTime FechaHoraFin { get; set; }

        public Paciente Paciente { get; set; }

        public Medico Medico { get; set; }
    }
}
