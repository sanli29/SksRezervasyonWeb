using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SksRezervasyon.Business.DTO.Misafirhane
{
    public class MisafirhaneRezervasyonListeleRequestDTO
    {
        public int? OgrenciId { get; set; }
    }

    public class MisafirhaneRezervasyonListeleResponsetDTO
    {
        public int MisafirhaneId { get; set; }
        public DateTime? GirisTarihi { get; set; }
        public string OdaTuru { get; set; }
    }
}
