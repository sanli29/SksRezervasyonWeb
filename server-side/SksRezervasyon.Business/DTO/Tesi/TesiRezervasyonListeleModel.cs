using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SksRezervasyon.Business.DTO.Tesi
{
    public class TesiRezervasyonListeleRequestDTO
    {
        public int? OgrenciId { get; set; }
    }

    public class TesiRezervasyonListeleResponsetDTO
    {
        public int TesisId { get; set; }
        public string TesisTur { get; set; }
        public string BaslangicSaati { get; set; }
        public DateTime? Tarih { get; set; }
    }
}
