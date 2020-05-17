using System.Collections.Generic;
using System;

namespace LeerData.Models
{
    public class Curso
    {
        public int CursoId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaPublicacion { get; set; }

        public byte[] FotoPortada { get; set; }

        public Precio PrecioPromocion { get; set; } // Ancla o Referencia a clase precio

        public ICollection<Comentario> ComentarioLista { get; set; }
        public ICollection<CursoInstructor> InstructorLink { get; set; }
    }
}