using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMVC.Models
{
    public class Especialidad
    {
        [Key]
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public List<MedicoEspecialidad> MedicosEspecialidad { get; set; }
    }
}
