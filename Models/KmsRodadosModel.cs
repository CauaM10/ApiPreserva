using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Api.Models
{
    public class KmsRodadosModel
    {

        public int KmsRodadosId { get; set; }

        public VeiculoModel Veiculo { get; set; }
        public int VeiculoId { get; set; }


        public int KmsRodados { get; set; }
        public DateTime KmsData { get; set; }

        public static implicit operator List<object>(KmsRodadosModel v)
        {
            throw new NotImplementedException();
        }
    }
}
