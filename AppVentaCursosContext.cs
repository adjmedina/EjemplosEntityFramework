using System.ComponentModel.DataAnnotations.Schema;
// Esta clase es el DbContext -> es la sesion con la base de datos

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using MySql.Data.EntityFrameworkCore.Extensions;

using LeerData.Models;
using LeerData.Config;

namespace LeerData
{
    public class AppVentaCursosContext : DbContext
    {
        public AppVentaCursosContext()
        {
            Database.SetCommandTimeout(150000);
        }
        private const string connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=CursosOnline;Integrated Security=True";

        private const string connectionStringMariaDB = @"server=localhost;port=3306;database=cursosonline;user=root;password=mariposa; old guids=true";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer(connectionStringMariaDB); // -> El optionBuilder solo hace la conexion
            optionsBuilder.UseMySQL(connectionStringMariaDB); // -> El Option buider para MySQL Requieres de Extensione
        }
        // Este metodo Protegido permite configurar el modelo antes de usarlo
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Este metodo permite configurar las entidades para realizar la conecciones a la base de datos 

            // En esta linea se le esta asignado dos llaves primarias a la entidad CursoInstructor
            //modelBuilder.Entity<CursoInstructor>().HasKey(ci => new { ci.InstructorId, ci.CursoId });

            //Para mayor organizacion
            new CursoInstructorConfig(modelBuilder.Entity<CursoInstructor>());

        }

        public DbSet<Curso> Curso { get; set; }
        public DbSet<Precio> Precio { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<CursoInstructor> CursoInstructor { get; set; }
    }
}