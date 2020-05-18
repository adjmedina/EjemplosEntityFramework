using System.Security.Authentication;
using System;
using Microsoft.EntityFrameworkCore;

using LeerData.Models;

namespace LeerData
{
    class Program
    {
        /// Lectura una tabla a traves  de una entidad
        public static void LecturaCurso()
        {
            //Llamada a dbContext - EL que conecta y entiende la db
            using (var db = new AppVentaCursosContext())
            {
                Console.WriteLine("*************************************************");
                // Lectura de una tabla Simple - Sin cache
                var cursos = db.Curso.AsNoTracking();
                foreach (Curso curso in cursos) // arreglo IQueryable
                {
                    Console.WriteLine($"Curso:  {curso.Titulo}. \nPublicado el: {curso.FechaPublicacion}.");
                    Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - -");
                }
                Console.WriteLine("*************************************************");
            }
        }

        //Ejemplo de lectura de dos entidades - Relación Uno a Uno
        public static void LecturaCursoPrecio()
        {

            using (var db = new AppVentaCursosContext())
            {
                Console.WriteLine("*************************************************");
                // El metodo include permite que se haga la consulta a la tabla promocion y lo guarde en la prop del curso
                var cursos = db.Curso.Include(p => p.PrecioPromocion).AsNoTracking();
                foreach (Curso curso in cursos) // arreglo IQueryable se pasa al tipo de dato que requiere
                {
                    Console.WriteLine("Curso: {0} - Precio Promoción: ${1} ", curso.Titulo, curso.PrecioPromocion.PrecioActual);
                    Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - -");
                }
            }
        }

        //Ejemplo de lectura de dos entidades - Uno a Muchos
        public static void LecturaCursoComentarios()
        {
            using (var db = new AppVentaCursosContext())
            {
                Console.WriteLine("*************************************************");
                var cursos = db.Curso.Include(c => c.ComentarioLista).AsNoTracking();
                foreach (Curso curso in cursos) // arreglo IQueryable se pasa al tipo de dato que requiere
                {
                    Console.WriteLine("{0} ----------- ", curso.Titulo);
                    Console.WriteLine("---------------------------------------------");
                    foreach (Comentario comentario in curso.ComentarioLista)
                    {
                        Console.WriteLine(comentario.ComentarioTexto);
                        Console.WriteLine("************************************");
                    }
                }
            }
        }

        // Ejemplo de consulta Muchos a Muchos
        public static void LecturaCursoProfesores()
        {
            using (var db = new AppVentaCursosContext())
            {
                // En esta linea se hace el cruce de las 3 tablas Curso ¬ CursoInstructor ¬ Instructor
                var cursos = db.Curso.Include(c => c.InstructorLink).ThenInclude(ci => ci.Instructor);
                foreach (Curso curso in cursos) // arreglo IQueryable se pasa al tipo de dato que requiere
                {
                    Console.WriteLine("**--- {0} ---**", curso.Titulo);
                    Console.WriteLine("-------------------- Profesores --------------------");
                    foreach (CursoInstructor instrLink in curso.InstructorLink)
                    {
                        Console.WriteLine("Nombre: -> {0} | {1} \n", instrLink.Instructor.Nombre, instrLink.Instructor.Apellidos);
                    }

                }
            }
        }


        static void Main(string[] args)
        {
            //Ejemplo de Lectura
            LecturaCursoProfesores();


        }
    }
}
