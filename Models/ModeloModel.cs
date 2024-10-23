using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Api.Models
{
    public class ModeloModel
    {
        public int ModeloId { get; set; }

        public string ModeloVeiculo { get; set; } = string.Empty;

        public string Foto { get; set; } = string.Empty;

        public int MarcaId { get; set; }

    }
}
