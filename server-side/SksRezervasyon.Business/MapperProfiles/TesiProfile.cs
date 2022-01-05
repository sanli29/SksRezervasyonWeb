using AutoMapper;
using SksRezervasyon.Business.DTO.Tesi;
using SksRezervasyon.Core.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SksRezervasyon.Business.MapperProfiles
{
    public class TesiProfile : Profile
    {
        public TesiProfile()
        {
            CreateMap<TesiRezervasyonIptalRequestDTO, Tesi>();
            CreateMap<Tesi, TesiRezervasyonIptalResponsetDTO>();

            CreateMap<TesiRezervasyonListeleRequestDTO, Tesi>();
            CreateMap<Tesi, TesiRezervasyonListeleResponsetDTO>();

            CreateMap<TesiRezervasyonMusaitListeleRequestDTO, Tesi>();
            CreateMap<Tesi, TesiRezervasyonMusaitListeleResponsetDTO>();

            CreateMap<TesiRezervasyonYapRequestDTO, Tesi>();
            CreateMap<Tesi, TesiRezervasyonYapResponsetDTO>();

        }
    }
}
