using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class MotoristaMap : IEntityTypeConfiguration<MotoristaModel>
    {
        public void Configure(EntityTypeBuilder<MotoristaModel> builder)
        {
            builder.HasKey(x => x.MotoristaId);
            builder.Property(x => x.NomeMotorista).IsRequired().HasMaxLength(255);
            builder.Property(x => x.TelefoneMotorista).IsRequired().HasMaxLength(255);
            builder.Property(x => x.EmailMotorista).IsRequired().HasMaxLength(255);
            builder.Property(x => x.CpfMotorista).IsRequired().HasMaxLength(255);
            builder.Property(x => x.IdadeMotorista).IsRequired().HasMaxLength(255);
        }
    }
}
