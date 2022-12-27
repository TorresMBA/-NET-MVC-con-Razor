using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    public class TurnoController : Controller
    {
        private readonly TurnosContext _context;

        private readonly IConfiguration _configuration;
        public TurnoController(TurnosContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            ViewData["IdMedico"] = new SelectList((from medico in _context.Medico.ToList() select new { IdMedico = medico.IdMedico, NombreCompleto = medico.Nombre + " " + medico.Apellido }), "IdMedico", "NombreCompleto");
            ViewData["IdPaciente"] = new SelectList((from paciente in _context.Paciente.ToList() select new { IdMedico = paciente.IdPaciente, NombreCompleto = paciente.Nombre + " " + paciente.Apellido }), "IdPaciente", "NombreCompleto");
            return View();
        }

        public JsonResult ObtenerTurnos(int idMedico)
        {
            List<Turno> turnos = new List<Turno>();
            turnos = _context.Turno.Where(t => t.IdMedico == idMedico).ToList();

            return Json(turnos);
        }

        [HttpPost]
        public JsonResult GrabarTurno(Turno turno)
        {
            var ok = false;
            try
            {
                _context.Turno.Add(turno);
                _context.SaveChanges();
                ok = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} GrabarTurno Exception Encontrada", ex);
                throw;
            }
            var jsonResult = new { response = ok };
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult EliminarTurno(int idTurno)
        {
            var ok = false;
            try
            {
                var turnoDelete = _context.Turno.Where(x => x.IdTurno == idTurno).FirstOrDefault();
                if (turnoDelete != null)
                {
                    _context.Turno.Remove(turnoDelete);
                    _context.SaveChanges();
                    ok = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} EliminarTurno Exception Encontrada", ex);
                throw;
            }
            var jsonResult = new { response = ok };
            return Json(jsonResult);
        }
    }
}
