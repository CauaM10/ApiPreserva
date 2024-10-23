using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Api.Models
{
    public class MarcaModel
    {

        public int MarcaId { get; set; }

        public string MarcaVeiculo { get; set; } = string.Empty;
    }
}
