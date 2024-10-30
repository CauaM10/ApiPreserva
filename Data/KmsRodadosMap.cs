using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class KmsRodadosMap : IEntityTypeConfiguration<KmsRodadosModel>
    {
        public void Configure(EntityTypeBuilder<KmsRodadosModel> builder)
        {
            builder.HasKey(x => x.KmsRodadosId);
            builder.Property(x => x.VeiculoId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.KmsRodados).IsRequired().HasMaxLength(255);
            builder.Property(x => x.KmsData).IsRequired(); 
        }
    }
}
