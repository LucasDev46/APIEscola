

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Business.Models;

namespace School.Data.Mappings
{
    public class ProfessorMapping : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
          
            builder.Property(p => p.RegistroFuncional)
                .IsRequired()
                .HasColumnType("varchar(20)");
            builder.HasIndex(p => p.RegistroFuncional)
                .IsUnique();

            builder.HasMany(p => p.Disciplina)
                .WithOne(d => d.Professor)
                .HasForeignKey(d => d.ProfessorId);
        }
    }
}
