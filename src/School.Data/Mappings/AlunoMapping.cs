using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Business.Models;

namespace School.Data.Mappings
{
    public class AlunoMapping : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            
            builder.Property(a => a.Matricula)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.HasIndex(a => a.Matricula)
                .IsUnique();

            builder.HasMany(a => a.DisciplinasMatriculadas)
                .WithOne(md => md.Aluno)
                .HasForeignKey(md => md.AlunoId);
        }
    }
}
