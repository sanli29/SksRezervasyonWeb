
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SksRezervasyon.Business.DTO.Tesi
{
    public class TesiRezervasyonMusaitListeleRequestDTO
    {
        public string TesisTur { get; set; }
        public DateTime? Tarih { get; set; }

    }

    public class TesiRezervasyonMusaitListeleResponsetDTO
    {
        public List<string> BaslangicSaati { get; set; }
    }
}
