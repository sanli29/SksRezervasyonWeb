using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SksRezervasyon.Business.DTO.Misafirhane
{
    public class MisafirhaneRezervasyonMusaitListeleRequestDTO
    {
        public DateTime? GirisTarihi { get; set; }

    }

    public class MisafirhaneRezervasyonMusaitListeleResponsetDTO
    {
        public List<string> OdaTuru { get; set; }
    }
}
