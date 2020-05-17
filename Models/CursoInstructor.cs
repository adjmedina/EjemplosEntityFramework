namespace LeerData.Models
{
    public class CursoInstructor
    {
        public int InstructorId { get; set; }
        public int CursoId { get; set; }

        // Referencias a las Otras Clases
        public Curso Curso { get; set; }
        public Instructor Instructor { get; set; }
    }
}