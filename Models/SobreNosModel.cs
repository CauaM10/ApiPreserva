
namespace Api.Models
{
    public class SobreNosModel
    {
        public int SobreNosId { get; set; }
        public string SobreEmpresa { get; set; } = string.Empty;
        public string ServicoEmpresa { get; set; } = string.Empty;
        public string ObjetivoEmpresa { get; set; } = string.Empty;

        public static implicit operator List<object>(SobreNosModel v)
        {
            throw new NotImplementedException();
        }
    }
}
