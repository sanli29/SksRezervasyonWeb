using AutoMapper;
using SksRezervasyon.Business.DTO.Ogrenci;
using SksRezervasyon.Core.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SksRezervasyon.Business.MapperProfiles
{
    public class OgrenciProfile : Profile
    {
        public OgrenciProfile()
        {
            CreateMap<OgrenciLoginRequestDTO, Ogrenci>();
            CreateMap<Ogrenci, OgrenciLoginResponsetDTO>();

            CreateMap<OgrenciRegisterRequestDTO, Ogrenci>();
            CreateMap<Ogrenci, OgrenciRegisterResponsetDTO>();

            CreateMap<OgrenciGetByIDRequestDTO, Ogrenci>();
            CreateMap<Ogrenci, OgrenciGetByIDResponsetDTO>();

        }
    }
}
