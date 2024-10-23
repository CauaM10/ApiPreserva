using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class VeiculoMap : IEntityTypeConfiguration<VeiculoModel>
    {
        public void Configure(EntityTypeBuilder<VeiculoModel> builder)
        {
            builder.HasKey(x => x.VeiculoId);
            builder.Property(x => x.ModeloId).IsRequired().HasMaxLength(255); 
            builder.Property(x => x.HodometroVeiculo).IsRequired().HasMaxLength(255);
            builder.Property(x => x.TipoCombustivelId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.MotoristaId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Consumo).IsRequired().HasMaxLength(255);

        }
    }
}