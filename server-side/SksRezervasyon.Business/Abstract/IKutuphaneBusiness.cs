using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SksRezervasyon.Business.DTO.Kutuphane;
using SksRezervasyon.Business.ServiceResponse;

namespace SksRezervasyon.Business.Abstract
{
    public interface IKutuphaneBusiness
    {
        ServiceResultResponse<KutuphaneRezervasyonIptalResponsetDTO> KutuphaneRezervasyonIptal(KutuphaneRezervasyonIptalRequestDTO entity);
        ServiceResultResponse<List<KutuphaneRezervasyonListeleResponsetDTO>> KutuphaneRezervasyonListele(KutuphaneRezervasyonListeleRequestDTO entity);
        ServiceResultResponse<KutuphaneRezervasyonMusaitListeleResponsetDTO> KutuphaneRezervasyonMusaitListele(KutuphaneRezervasyonMusaitListeleRequestDTO entity);
        ServiceResultResponse<KutuphaneRezervasyonYapResponsetDTO> KutuphaneRezervasyonYap(KutuphaneRezervasyonYapRequestDTO entity);

    }
}
