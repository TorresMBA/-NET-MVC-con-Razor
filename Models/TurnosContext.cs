using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMVC.Models
{
    public class TurnosContext : DbContext
    {
        public TurnosContext(DbContextOptions<TurnosContext> options) : base(options)
        {

        }

        public DbSet<Especialidad> Especialidad { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Especialidad>(entidad => {
                entidad.ToTable("Especialidad"); //Nombre de la tabla
                entidad.HasKey(e => e.Id); //Primary key
                entidad.Property(e => e.Descripcion).IsRequired().HasMaxLength(200).IsUnicode(false); //agregar nuevo campo y debe se requerido
            });
        }
    }
}
