using AutoMapper;
using SksRezervasyon.Business.DTO.Yemekhane;
using SksRezervasyon.Core.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SksRezervasyon.Business.MapperProfiles
{
    public class YemekhaneProfile : Profile
    {
        public YemekhaneProfile()
        {
            CreateMap<YemekhaneRezervasyonIptalRequestDTO, Yemekhane>();
            CreateMap<Yemekhane, YemekhaneRezervasyonIptalResponsetDTO>();

            CreateMap<YemekhaneRezervasyonListeleRequestDTO, Yemekhane>();
            CreateMap<Yemekhane, YemekhaneRezervasyonListeleResponsetDTO>();

            CreateMap<YemekhaneRezervasyonMusaitListeleRequestDTO, Yemekhane>();
            CreateMap<Yemekhane, YemekhaneRezervasyonMusaitListeleResponsetDTO>();

            CreateMap<YemekhaneRezervasyonYapRequestDTO, Yemekhane>();
            CreateMap<Yemekhane, YemekhaneRezervasyonYapResponsetDTO>();

        }
    }
}
