using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SksRezervasyon.Business.DTO.Yemekhane;
using SksRezervasyon.Business.ServiceResponse;

namespace SksRezervasyon.Business.Abstract
{
    public interface IYemekhaneBusiness
    {
        ServiceResultResponse<YemekhaneRezervasyonIptalResponsetDTO> YemekhaneRezervasyonIptal(YemekhaneRezervasyonIptalRequestDTO entity);
        ServiceResultResponse<List<YemekhaneRezervasyonListeleResponsetDTO>> YemekhaneRezervasyonListele(YemekhaneRezervasyonListeleRequestDTO entity);
        ServiceResultResponse<List<YemekhaneRezervasyonMusaitListeleResponsetDTO>> YemekhaneRezervasyonMusaitListele(YemekhaneRezervasyonMusaitListeleRequestDTO entity);
        ServiceResultResponse<YemekhaneRezervasyonYapResponsetDTO> YemekhaneRezervasyonYap(YemekhaneRezervasyonYapRequestDTO entity);

    }
}
