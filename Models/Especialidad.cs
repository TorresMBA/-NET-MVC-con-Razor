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

        [Display(Name = "Descripción", Prompt = "Ingrese una descripción")]
        [Required(ErrorMessage = "Debe ingresar una descripción")]
        [StringLength(200, ErrorMessage = "El campo descripción debe tener Máximo 200 caracteres")]
        public string Descripcion { get; set; }

        public List<MedicoEspecialidad> MedicosEspecialidad { get; set; }
    }
}
