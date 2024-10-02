using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Api.Models
{
    public class ConsumoModel
    {
        public int ConsumoId { get; set; }
        public int ConsumoKm { get; set; }

        public static implicit operator List<object>(ConsumoModel v)
        {
            throw new NotImplementedException();
        }
    }
}
