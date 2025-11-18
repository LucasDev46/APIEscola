using Microsoft.EntityFrameworkCore;
using School.Business.Models;

namespace School.Data.Mappings
{
    public class PessoaMapping : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Email)
                .IsRequired()
                .HasColumnType("varchar(100)");
            builder.HasIndex(p => p.Email)
                .IsUnique();

            builder.Property(p => p.DataNascimento)
                .IsRequired()
                .HasColumnType("datetime");
            
            builder.Property(p => p.Tipo)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Ativo)
                .IsRequired()
                .HasColumnType("bit");
        }
    }
}
