using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SksRezervasyon.Business.DTO.Ogrenci
{
    public class OgrenciGetByIDRequestDTO
    {
        public int OgrenciId { get; set; }
    }

    public class OgrenciGetByIDResponsetDTO
    {
        public int OgrenciId { get; set; }
        public string Email { get; set; }
        public string Adi { get; set; }
        public string Sifre { get; set; }
        public bool? Status { get; set; }
        public DateTime? CreatedAt { get; set; }

    }
}
