using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LeerData.Models;

namespace LeerData.Config
{
    public class CursoInstructorConfig
    {
        public CursoInstructorConfig(EntityTypeBuilder<CursoInstructor> entityBuilder)
        {
            entityBuilder.HasKey(ci => new { ci.InstructorId, ci.CursoId });
        }
    }
}