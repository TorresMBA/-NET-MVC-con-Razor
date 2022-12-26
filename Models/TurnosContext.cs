using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVC.Models;

namespace WebAppMVC.Models
{
    public class TurnosContext : DbContext
    {
        public TurnosContext(DbContextOptions<TurnosContext> options) : base(options)
        {

        }

        public DbSet<Especialidad> Especialidad { get; set; }

        public DbSet<Paciente> Paciente { get; set; }

        public DbSet<Medico> Medico { get; set; }

        public DbSet<MedicoEspecialidad> MedicoEspecialidad { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Especialidad>(entidad => {
                entidad.ToTable("Especialidad"); //Nombre de la tabla
                entidad.HasKey(e => e.Id); //Primary key
                entidad.Property(e => e.Descripcion).IsRequired().HasMaxLength(200).IsUnicode(false); //agregar nuevo campo y debe se requerido
            });

            modelBuilder.Entity<Paciente>(entidad => {
                entidad.ToTable("Paciente");
                entidad.HasKey(p => p.IdPaciente);
                entidad.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(e => e.Apellido)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(e => e.Dirrecion)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

                entidad.Property(e => e.Telefono)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

                entidad.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Medico>( entidad => {
                entidad.ToTable("Medico");
                entidad.HasKey(p => p.IdMedico);
                entidad.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(e => e.Apellido)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(e => e.Dirrecion)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

                entidad.Property(e => e.Telefono)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

                entidad.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

                entidad.Property(e => e.HorarioAtencionDesde)
                .IsRequired()
                .IsUnicode(false);

                entidad.Property(e => e.HorarioAtencionHasta)
                .IsRequired()
                .IsUnicode(false);
            });

            modelBuilder.Entity<MedicoEspecialidad>()
                .HasKey(x => new { x.IdMedico, x.IdEspecialidad });//Lo que se hace acá es que definimos una primary key compuesta por esos dos campos

            //Acá lo que hicimos fue definira una relación entre medico y medicoespecialidad
            //con la propiedad hasone y withmany 1:N, un medico puede tener muchas especialidas
            //y con el metodo hasforeignkey es establecer que propiedad va a formar parte esta foring key
            modelBuilder.Entity<MedicoEspecialidad>().HasOne(x => x.Medico)
                .WithMany(p => p.MedicoEspecialidades)
                .HasForeignKey(t => t.IdMedico);

            modelBuilder.Entity<MedicoEspecialidad>().HasOne(x => x.Especialidad)
                .WithMany(p => p.MedicosEspecialidad)
                .HasForeignKey(t => t.IdEspecialidad);
        }
    }
}
