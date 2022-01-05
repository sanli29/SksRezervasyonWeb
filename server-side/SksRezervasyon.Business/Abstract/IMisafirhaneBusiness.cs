using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SksRezervasyon.Business.DTO.Misafirhane;
using SksRezervasyon.Business.ServiceResponse;

namespace SksRezervasyon.Business.Abstract
{
    public interface IMisafirhaneBusiness
    {
        ServiceResultResponse<MisafirhaneRezervasyonIptalResponsetDTO> MisafirhaneRezervasyonIptal(MisafirhaneRezervasyonIptalRequestDTO entity);
        ServiceResultResponse<List<MisafirhaneRezervasyonListeleResponsetDTO>> MisafirhaneRezervasyonListele(MisafirhaneRezervasyonListeleRequestDTO entity);
        ServiceResultResponse<MisafirhaneRezervasyonMusaitListeleResponsetDTO> MisafirhaneRezervasyonMusaitListele(MisafirhaneRezervasyonMusaitListeleRequestDTO entity);
        ServiceResultResponse<MisafirhaneRezervasyonYapResponsetDTO> MisafirhaneRezervasyonYap(MisafirhaneRezervasyonYapRequestDTO entity);

    }
}
