using AutoMapper;
using SksRezervasyon.Business.DTO.Misafirhane;
using SksRezervasyon.Core.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SksRezervasyon.Business.MapperProfiles
{
    public class MisafirhaneProfile : Profile
    {
        public MisafirhaneProfile()
        {
            CreateMap<MisafirhaneRezervasyonIptalRequestDTO, Misafirhane>();
            CreateMap<Misafirhane, MisafirhaneRezervasyonIptalResponsetDTO>();

            CreateMap<MisafirhaneRezervasyonListeleRequestDTO, Misafirhane>();
            CreateMap<Misafirhane, MisafirhaneRezervasyonListeleResponsetDTO>();

            CreateMap<MisafirhaneRezervasyonMusaitListeleRequestDTO, Misafirhane>();
            CreateMap<Misafirhane, MisafirhaneRezervasyonMusaitListeleResponsetDTO>();

            CreateMap<MisafirhaneRezervasyonYapRequestDTO, Misafirhane>();
            CreateMap<Misafirhane, MisafirhaneRezervasyonYapResponsetDTO>();

        }
    }
}
