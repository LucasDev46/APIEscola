using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Business.Models;


namespace School.Data.Mappings
{
    internal class MatriculaDisciplinaMapping : IEntityTypeConfiguration<MatriculaDisciplina>
    {
        public void Configure(EntityTypeBuilder<MatriculaDisciplina> builder)
        {
            builder.HasKey(md => md.Id);

            // Relacionamento com Aluno
            builder.HasOne(md => md.Aluno)
                   .WithMany(a => a.DisciplinasMatriculadas) // Aluno tem ICollection<MatriculaDisciplina>
                   .HasForeignKey(md => md.AlunoId)
                   .OnDelete(DeleteBehavior.Cascade); // se o aluno for deletado, apagar matrícula

            // Relacionamento com Disciplina
            builder.HasOne(md => md.Disciplina)
                   .WithMany(d => d.Matriculas) // Disciplina tem ICollection<MatriculaDisciplina>
                   .HasForeignKey(md => md.DisciplinaId)
                   .OnDelete(DeleteBehavior.Restrict); // não apagar disciplina se tiver matrícula

            // Relacionamento com Notas
            builder.HasMany(md => md.Notas)
                   .WithOne(n => n.MatriculaDisciplina)
                   .HasForeignKey(n => n.MatriculaDisciplinaId)
                   .OnDelete(DeleteBehavior.Cascade); // se matrícula deletada, apaga notas

            builder.Property(md => md.NotaFinal)
                   .HasPrecision(5, 2);
        }
    }
}
