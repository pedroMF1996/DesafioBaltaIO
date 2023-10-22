using DesafioBaltaIO.Domain.IBGE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioBaltaIO.Data.IBGE.Mapping
{
    public class LocalidadeMapping : IEntityTypeConfiguration<LocalidadeModel>
    {
        public void Configure(EntityTypeBuilder<LocalidadeModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Codigo)
                .IsRequired()
                .HasColumnType("TEXT")
                .HasMaxLength(7);

            builder.Property(x => x.Estado)
                .IsRequired()
                .HasColumnType("TEXT")
                .HasMaxLength(2);

            builder.Property(x => x.Cidade)
                .IsRequired()
                .HasColumnType("TEXT");

            builder.Property(x => x.CadastradoPor)
                .IsRequired()
                .HasColumnType("TEXT")
                .HasDefaultValue(Guid.Empty);

            builder.Property(x => x.EditadoPor)
                .IsRequired()
                .HasColumnType("TEXT")
                .HasDefaultValue(Guid.Empty);

            builder.Property(x => x.DataCadastro)
                .IsRequired()
                .HasColumnType("INTEGER")
                .HasDefaultValue(DateTime.MinValue);

            builder.Property(x => x.DataEdicao)
                .IsRequired()
                .HasColumnType("INTEGER")
                .HasDefaultValue(DateTime.MinValue);

            builder.ToTable("Localidades");
        }
    }
}
