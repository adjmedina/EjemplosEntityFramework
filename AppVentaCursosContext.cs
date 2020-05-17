using System.Reflection.Emit;
// Esta clase es el DbContext -> es la sesion con la base de datos

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

using LeerData.Models;

namespace LeerData
{
    public class AppVentaCursosContext : DbContext
    {
        private const string connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=CursosOnline;Integrated Security=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString); // -> El optionBuilder solo hace la coneccion
        }
        // Este metodo Protegido permite configurar el modelo antes de usarlo
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // En esta linea se le esta asignado dos llaves primarias a la entidad CursoInstructor
            modelBuilder.Entity<CursoInstructor>().HasKey(ci => new { ci.InstructorId, ci.CursoId });

            //modelBuilder.Entity<Instructor>().HasKey(i => i.InstructorId);
        }

        public DbSet<Curso> Curso { get; set; }
        public DbSet<Precio> Precio { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<CursoInstructor> CursoInstructor { get; set; }
    }
}