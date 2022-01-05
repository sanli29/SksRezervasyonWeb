using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SksRezervasyon.Business.DTO.Kutuphane
{
    public class KutuphaneRezervasyonListeleRequestDTO
    {
        public int? OgrenciId { get; set; }

    }

    public class KutuphaneRezervasyonListeleResponsetDTO
    {
        public int KutuphaneId { get; set; }
       
        public DateTime? Tarih { get; set; }
     
        public string BaslangicSaati { get; set; }
        public int? OdaNo { get; set; }

    }

}
