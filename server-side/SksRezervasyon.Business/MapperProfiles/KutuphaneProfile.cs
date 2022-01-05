using AutoMapper;
using SksRezervasyon.Business.DTO.Kutuphane;
using SksRezervasyon.Core.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SksRezervasyon.Business.MapperProfiles
{
    public class KutuphaneProfile : Profile
    {
        public KutuphaneProfile()
        {
            CreateMap<KutuphaneRezervasyonIptalRequestDTO, Kutuphane>();
            CreateMap<Kutuphane, KutuphaneRezervasyonIptalResponsetDTO>();

            CreateMap<KutuphaneRezervasyonListeleRequestDTO, Kutuphane>();
            CreateMap<Kutuphane, KutuphaneRezervasyonListeleResponsetDTO>();

            CreateMap<KutuphaneRezervasyonMusaitListeleRequestDTO, Kutuphane>();
            CreateMap<Kutuphane, KutuphaneRezervasyonMusaitListeleResponsetDTO>();

            CreateMap<KutuphaneRezervasyonYapRequestDTO, Kutuphane>();
            CreateMap<Kutuphane, KutuphaneRezervasyonYapResponsetDTO>();

        }
    }
}
