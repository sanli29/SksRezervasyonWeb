using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SksRezervasyon.Business.DTO.Yemekhane
{
    public class YemekhaneRezervasyonYapRequestDTO
    {
        public int? OgrenciId { get; set; }
        public DateTime? Tarih { get; set; }
        public int IsRandevu { get; set; }
        public string Fiyat { get; set; }

        public string Ogun { get; set; }
    }

    public class YemekhaneRezervasyonYapResponsetDTO
    {

    }
}
