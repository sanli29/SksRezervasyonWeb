using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SksRezervasyon.Business.DTO.Misafirhane
{
    public class MisafirhaneRezervasyonYapRequestDTO
    {
        public int? OgrenciId { get; set; }
        public DateTime? GirisTarihi { get; set; }
        public string OdaTuru { get; set; }
    }

    public class MisafirhaneRezervasyonYapResponsetDTO
    {

    }
}
