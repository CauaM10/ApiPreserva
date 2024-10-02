using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class CadastroEmpresaMap : IEntityTypeConfiguration<CadastroEmpresaModel>
    {
        public void Configure(EntityTypeBuilder<CadastroEmpresaModel> builder)
        {
            builder.HasKey(x => x.CadastroEmpresaId);
            builder.Property(x=> x.NomeEmpresa).IsRequired().HasMaxLength(255);
            builder.Property(x => x.CnpjEmpresa).IsRequired().HasMaxLength(255);
            builder.Property(x => x.TelefoneEmpresa).IsRequired().HasMaxLength(255);
            builder.Property(x => x.EmailEmpresa).IsRequired().HasMaxLength(255);
            builder.Property(x => x.SenhaEmpresa).IsRequired().HasMaxLength(255);
        }
    }
}
