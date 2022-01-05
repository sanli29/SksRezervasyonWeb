using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SksRezervasyon.Business.DTO.Kutuphane
{
    public class KutuphaneRezervasyonMusaitListeleRequestDTO
    {
        public DateTime? Tarih { get; set; }
        public int? OdaNo { get; set; }
    }

    public class KutuphaneRezervasyonMusaitListeleResponsetDTO
    {
        public List<string> BaslangicSaati { get; set; }
    }
}
