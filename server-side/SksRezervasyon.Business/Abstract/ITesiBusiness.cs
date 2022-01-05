using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SksRezervasyon.Business.DTO.Tesi;
using SksRezervasyon.Business.ServiceResponse;

namespace SksRezervasyon.Business.Abstract
{
    public interface ITesiBusiness
    {
        ServiceResultResponse<TesiRezervasyonIptalResponsetDTO> TesiRezervasyonIptal(TesiRezervasyonIptalRequestDTO entity);
        ServiceResultResponse<List<TesiRezervasyonListeleResponsetDTO>> TesiRezervasyonListele(TesiRezervasyonListeleRequestDTO entity);
        ServiceResultResponse<TesiRezervasyonMusaitListeleResponsetDTO> TesiRezervasyonMusaitListele(TesiRezervasyonMusaitListeleRequestDTO entity);
        ServiceResultResponse<TesiRezervasyonYapResponsetDTO> TesiRezervasyonYap(TesiRezervasyonYapRequestDTO entity);

    }
}
