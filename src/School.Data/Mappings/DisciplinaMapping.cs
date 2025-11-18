
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Business.Models;

namespace School.Data.Mappings
{
    public class DisciplinaMapping : IEntityTypeConfiguration<Disciplina>
    {
        public void Configure(EntityTypeBuilder<Disciplina> builder)
        {

            builder.HasKey(p => p.Id);
            builder.Property(d => d.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            // relacionamento com professor
            builder.HasOne(d => d.Professor)
                .WithMany(p => p.Disciplina)
                .HasForeignKey(d => d.ProfessorId)
                .OnDelete(DeleteBehavior.Restrict); // evita deletar prof se houver disciplina

            builder.HasMany(d => d.Matriculas)
                .WithOne(md => md.Disciplina)
                .HasForeignKey(md => md.DisciplinaId);
        }
    }
}
