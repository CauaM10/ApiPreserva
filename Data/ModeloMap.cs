using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class ModeloMap : IEntityTypeConfiguration<ModeloModel>
    {
        public void Configure(EntityTypeBuilder<ModeloModel> builder)
        {
            builder.HasKey(x => x.ModeloId);
            builder.Property(x => x.ModeloVeiculo).IsRequired().HasMaxLength(255); 
            builder.Property(x => x.Foto).IsRequired().HasMaxLength(255);
            builder.Property(x => x.MarcaId).IsRequired().HasMaxLength(255);
        }
    }
}
