using System.Security.Authentication;
using System;
using Microsoft.EntityFrameworkCore;

using LeerData.Models;

namespace LeerData
{
    class Program
    {
        static void Main(string[] args)
        {
            /* -- Ejemplos
            //Ejemplo de lectura de una entidad
            using (var db = new AppVentaCursosContext())
            {
                // Lectura Simple - SIn cache
                var cursos = db.Curso.AsNoTracking();
                foreach (Curso curso in cursos) // arreglo IQueryable
                {
                    // String interpolation:
                    Console.WriteLine($"CURSO:  {curso.Titulo}, Publicado el: {curso.FechaPublicacion}.");
                }
            }

            //Ejemplo de lectura de dos entidades - Uno a Uno
            using (var db = new AppVentaCursosContext())
            {
                var cursos = db.Curso.Include(p => p.PrecioPromocion).AsNoTracking();
                foreach (Curso curso in cursos) // arreglo IQueryable se pasa al tipo de dato que requiere
                {
                    // Composite formatting:
                    Console.WriteLine("{0} ----------- {1} ", curso.Titulo, curso.PrecioPromocion.PrecioActual);
                }
            }

            //Ejemplo de lectura de dos entidades - Uno a Muchos
            using (var db = new AppVentaCursosContext())
            {
                var cursos = db.Curso.Include(c => c.ComentarioLista).AsNoTracking();
                foreach (Curso curso in cursos) // arreglo IQueryable se pasa al tipo de dato que requiere
                {
                    // Composite formatting:
                    Console.WriteLine("{0} ----------- ", curso.Titulo);
                    Console.WriteLine("---------------------------------------------");
                    foreach (Comentario comentario in curso.ComentarioLista)
                    {
                        Console.WriteLine(comentario.ComentarioTexto);
                        Console.WriteLine("************************************");
                    }
                }
            }
            --- */
            // Ejemplo de consulta Muchos a Muchos
            /* using (var db = new AppVentaCursosContext())
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
             } */

            // Ejemplo de Agragar
            using (var db = new AppVentaCursosContext())
            {
                // En esta linea se hace el cruce de las 3 tablas Curso ¬ CursoInstructor ¬ Instructor
                var instrLink = db.Curso.AsNoTracking();
                foreach (var ins in instrLink) // arreglo IQueryable se pasa al tipo de dato que requiere
                {
                    Console.WriteLine("**--- {0} ---**", ins);
                }
            }

        }
    }
}
