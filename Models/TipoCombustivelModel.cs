namespace Api.Models
{
    public class TipoCombustivelModel
    {
        public int TipoCombustivelId { get; set; }
        public string Combustivel { get; set; } = string.Empty;

        public static implicit operator List<object>(TipoCombustivelModel v)
        {
            throw new NotImplementedException();
        }
    }
}
