using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Api.Models
{
    public class VeiculoModel
    {
        public int VeiculoId { get; set; }

        public string ModeloVeiculo { get; set; } = string.Empty;

        public string MarcaVeiculo { get; set; } = string.Empty;
        public int HodometroVeiculo { get; set; }

        public int TipoCombustivelId { get; set; }

        public int MotoristaId { get; set; }

        public int ConsumoId { get; set; }


        public static implicit operator List<object>(VeiculoModel v)
        {
            throw new NotImplementedException();
        }
    }
}
