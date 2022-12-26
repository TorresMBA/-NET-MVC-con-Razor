﻿using System;
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

        [Required(ErrorMessage = "Debe ingresar un nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar un apellido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Debe ingresar una dirección")]
        public string Dirrecion { get; set; }

        [Required(ErrorMessage = "Debe ingresar un teléfono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Debe ingresar un email")]
        [EmailAddress(ErrorMessage = "No es una dirección de email válida")]
        public string Email { get; set; }
    }
}
