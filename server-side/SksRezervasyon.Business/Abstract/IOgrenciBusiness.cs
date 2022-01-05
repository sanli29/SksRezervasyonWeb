using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SksRezervasyon.Business.DTO.Ogrenci;
using SksRezervasyon.Business.ServiceResponse;

namespace SksRezervasyon.Business.Abstract
{
    public interface IOgrenciBusiness
    {
        ServiceResultResponse<OgrenciLoginResponsetDTO> Login(OgrenciLoginRequestDTO entity);
        ServiceResultResponse<OgrenciRegisterResponsetDTO> Register(OgrenciRegisterRequestDTO entity);
        ServiceResultResponse<OgrenciGetByIDResponsetDTO> GetById(OgrenciGetByIDRequestDTO entity);

    }
}
