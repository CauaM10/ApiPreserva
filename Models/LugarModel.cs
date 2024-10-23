
namespace Api.Models
{
    public class LugarModel
    {
        public int LugarId { get; set; }

        public string Foto { get; set; } = string.Empty;

        public string EndereçoLugar { get; set; } = string.Empty;

        public string DetalhesLugar { get; set; } = string.Empty;

        public string ObjetivoLugar { get; set; } = string.Empty;
    }
}
