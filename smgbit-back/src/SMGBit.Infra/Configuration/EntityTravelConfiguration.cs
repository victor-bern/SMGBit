using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMGBit.Domain.Entities;
using SMGBit.Domain.ValueObjects;

namespace SMGBit.Infra.Configuration
{
    public class EntityTravelConfiguration : IEntityTypeConfiguration<Travel>
    {
        public void Configure(EntityTypeBuilder<Travel> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();

            builder.Property(t => t.DataViagem)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(t => t.NumeroViagem)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(t => t.Motorista)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar");

            builder.Property(t => t.Placa)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar");

            builder.Property(t => t.TipoVeiculo)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(50)
                .HasConversion(
                    v => v.ToString(),
                    v => (TipoVeiculo)Enum.Parse(typeof(TipoVeiculo), v))
                .HasColumnType("varchar");

            builder.Property(t => t.TipoViagem)
                .HasMaxLength(50)
                .HasConversion(
                    v => v.ToString(),
                    v => (TipoViagem)Enum.Parse(typeof(TipoViagem), v))
                .HasColumnType("varchar");

            builder.Property(t => t.CaixasCarregagas)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(t => t.Entregas)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(t => t.KmRodados)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(t => t.TabelaFrete)
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .IsRequired(false);

            builder.Property(t => t.ValorViagem)
                .HasColumnType("int")
                .IsRequired(false);

        }
    }
}
