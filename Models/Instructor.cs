using System.Collections.Generic;
namespace LeerData.Models
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Grado { get; set; }
        public byte[] FotoPerfil { get; set; }
        // public ICollection<Curso> Cursos { get; set; }
        public ICollection<CursoInstructor> CursoLink { get; set; }
    }
}