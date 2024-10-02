
namespace Api.Models
{
    public class MotoristaModel
    {
        public int MotoristaId { get; set; }

        public string NomeMotorista { get; set; } = string.Empty;

        public int TelefoneMotorista { get; set; }

        public string EmailMotorista { get; set; } = string.Empty;

        public int CpfMotorista { get; set; }

        public int IdadeMotorista { get; set; }

        public static implicit operator List<object>(MotoristaModel v)
        {
            throw new NotImplementedException();
        }
    }
}
