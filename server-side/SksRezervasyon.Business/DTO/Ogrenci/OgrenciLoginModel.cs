using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SksRezervasyon.Business.DTO.Ogrenci
{
    public class OgrenciLoginRequestDTO
    {
        public string Email { get; set; }
        public string Sifre { get; set; }
    }

    public class OgrenciLoginResponsetDTO
    {
        public int OgrenciId { get; set; }
    }
}
