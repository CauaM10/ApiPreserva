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
            builder.Property(x => x.ModeloVeiculo).IsRequired().HasMaxLength(255); 
            builder.Property(x => x.MarcaVeiculo).IsRequired().HasMaxLength(255);
            builder.Property(x => x.HodometroVeiculo).IsRequired().HasMaxLength(255);
            builder.Property(x => x.TipoCombustivelId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.MotoristaId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ConsumoId).IsRequired().HasMaxLength(255);

        }
    }
}