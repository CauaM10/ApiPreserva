using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class SobreNosMap : IEntityTypeConfiguration<SobreNosModel>
    {
        public void Configure(EntityTypeBuilder<SobreNosModel> builder)
        {
            builder.HasKey(x => x.SobreNosId);
            builder.Property(x => x.SobreEmpresa).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ServicoEmpresa).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ObjetivoEmpresa).IsRequired().HasMaxLength(255);

        }
    }
}
