using AutoMapper;
using FluentValidation;
using SksRezervasyon.Business.Abstract;
using SksRezervasyon.Business.DTO.Ogrenci;
using SksRezervasyon.Business.FluentValidation.Ogrenci;
using SksRezervasyon.Business.ServiceResponse;
using SksRezervasyon.Core.Repository.Models;
using SksRezervasyon.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SksRezervasyon.Business.Concretes
{
    public class OgrenciBusiness : IDisposable, IOgrenciBusiness
    {
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

        private readonly IOgrenciRepository ogrenciRepository;
        private readonly IMapper mapper;

        public OgrenciBusiness(IMapper mapper, IOgrenciRepository ogrenciRepository)
        {
            this.mapper = mapper;
            this.ogrenciRepository = ogrenciRepository;
        }

        public ServiceResultResponse<OgrenciLoginResponsetDTO> Login(OgrenciLoginRequestDTO entity)
        {
            try
            {
                var validator = new OgrenciLoginValidator();
                var result = validator.Validate(entity);
                if (result.IsValid)
                {
                    var succesOgrenci = ogrenciRepository.Get(x => x.Sifre.Equals(entity.Sifre) && x.Email.Equals(entity.Email));
                    if (succesOgrenci != null)
                    {
                        var loginResponsetDTO = mapper.Map<OgrenciLoginResponsetDTO>(succesOgrenci);
                        return ServiceResponseBuilder.SuccessResponse<OgrenciLoginResponsetDTO>(loginResponsetDTO);
                    }
                    else
                    {
                        return ServiceResponseBuilder.FailResponse<OgrenciLoginResponsetDTO>("Böyle Bir Kullanıcı Bulunmamaktadır.");
                    }
                }
                return ServiceResponseBuilder.FailResponse<OgrenciLoginResponsetDTO>(result.Errors[0].ErrorMessage);

            }
            catch (Exception ex)
            {

                throw new Exception("Login İşleminde Hata", ex);
            }
        }

        public ServiceResultResponse<OgrenciRegisterResponsetDTO> Register(OgrenciRegisterRequestDTO entity)
        {
            try
            {
                var validator = new OgrenciRegisterValidator();
                var result = validator.Validate(entity);
                if (result.IsValid)
                {
                    if (ogrenciRepository.CheckEmail(entity.Email))
                    {
                        var succesOgrenci = ogrenciRepository.Add(mapper.Map<Ogrenci>(entity));

                        var registerResponsetDTO = mapper.Map<OgrenciRegisterResponsetDTO>(succesOgrenci);
                        return ServiceResponseBuilder.SuccessResponse<OgrenciRegisterResponsetDTO>(registerResponsetDTO);
                    }
                    else
                    {
                        return ServiceResponseBuilder.FailResponse<OgrenciRegisterResponsetDTO>("Bu mail sistemde bulunmaktadır.");
                    }

                }
                return ServiceResponseBuilder.FailResponse<OgrenciRegisterResponsetDTO>(result.Errors[0].ErrorMessage);

            }
            catch (Exception ex)
            {

                throw new Exception("Register İşleminde Hata", ex);
            }
        }

        public ServiceResultResponse<OgrenciGetByIDResponsetDTO> GetById(OgrenciGetByIDRequestDTO entity)
        {
            try
            {
                var validator = new OgrenciGetByIDValidator();
                var result = validator.Validate(entity);
                if (result.IsValid)
                { 
                    var succesUser = ogrenciRepository.GetById(entity.OgrenciId);
                    if (succesUser != null)
                    {
                        var ogrenciGetByIDResponsetDTO = mapper.Map<OgrenciGetByIDResponsetDTO>(succesUser);
                        return ServiceResponseBuilder.SuccessResponse<OgrenciGetByIDResponsetDTO>(ogrenciGetByIDResponsetDTO);
                    }
                    else
                    {
                        return ServiceResponseBuilder.FailResponse<OgrenciGetByIDResponsetDTO>("Böyle bir kullanıcı bulunamadı");
                    }                   
                }
                return ServiceResponseBuilder.FailResponse<OgrenciGetByIDResponsetDTO>(result.Errors[0].ErrorMessage);

            }
            catch (Exception ex)
            {
                throw new Exception("Get By ID işleminde hata", ex);
            }
        }
    }
}
