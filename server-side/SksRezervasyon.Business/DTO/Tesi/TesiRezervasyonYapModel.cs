using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SksRezervasyon.Business.DTO.Tesi
{
    public class TesiRezervasyonYapRequestDTO
    {
        public int? OgrenciId { get; set; }
        public string TesisTur { get; set; }
        public DateTime? Tarih { get; set; }
        public string BaslangicSaati { get; set; }
    }

    public class TesiRezervasyonYapResponsetDTO
    {

    }
}
