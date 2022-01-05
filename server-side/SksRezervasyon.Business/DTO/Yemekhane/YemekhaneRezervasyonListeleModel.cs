using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SksRezervasyon.Business.DTO.Yemekhane
{
    public class YemekhaneRezervasyonListeleRequestDTO
    {
        public int? OgrenciId { get; set; }
       
    }

    public class YemekhaneRezervasyonListeleResponsetDTO
    {
        public int YemekhaneId { get; set; }
        public DateTime? Tarih { get; set; }
        public string Fiyat { get; set; }
        public string Ogun { get; set; }
    }
}
