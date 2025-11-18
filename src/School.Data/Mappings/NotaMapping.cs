
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Business.Models;

namespace School.Data.Mappings
{
    public class NotaMapping : IEntityTypeConfiguration<Nota>
    {
        public void Configure(EntityTypeBuilder<Nota> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Valor)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            builder.Property(n => n.Peso)
                .IsRequired()
                .HasColumnType("decimal(3,2)");

            builder.Property(n => n.Descricao)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.HasOne(n => n.MatriculaDisciplina)
                .WithMany(md => md.Notas)
                .HasForeignKey(n => n.MatriculaDisciplinaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
