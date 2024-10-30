using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Api.Models
{
    public class VeiculoModel
    {

        public int VeiculoId { get; set; }

        public string placaVeiculo { get; set; }

        public TipoCombustivelModel TipoCombustivel { get; set; }
        public int TipoCombustivelId { get; set; }

        public ModeloModel Modelo { get; set; }

        public int ModeloId { get; set; }

        public MotoristaModel Motorista { get; set; }

        public int MotoristaId { get; set; }

        public double Consumo { get; set; }


        public static implicit operator List<object>(VeiculoModel v)
        {
            throw new NotImplementedException();
        }
    }
}
