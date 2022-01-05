using AutoMapper;
using SksRezervasyon.Business.Abstract;
using SksRezervasyon.Business.DTO.Yemekhane;
using SksRezervasyon.Business.FluentValidation.Yemekhane;
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
    public class YemekhaneBusiness : IDisposable, IYemekhaneBusiness
    {
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

        private readonly IYemekhaneRepository yemekhaneRepository;
        private readonly IMapper mapper;

        public YemekhaneBusiness(IMapper mapper, IYemekhaneRepository yemekhaneRepository)
        {
            this.mapper = mapper;
            this.yemekhaneRepository = yemekhaneRepository;
        }
        public ServiceResultResponse<YemekhaneRezervasyonIptalResponsetDTO> YemekhaneRezervasyonIptal(YemekhaneRezervasyonIptalRequestDTO entity)
        {
            try
            {
                var validator = new YemekhaneRezervasyonIptalValidator();
                var result = validator.Validate(entity);
                if (result.IsValid)
                {
                    var deletedYemekhaneRezervasyon = yemekhaneRepository.Delete(entity.YemekhaneId);
                    if (deletedYemekhaneRezervasyon != null)
                    {
                        var deletedYemekhaneRezervasyonResponsetDTO = mapper.Map<YemekhaneRezervasyonIptalResponsetDTO>(deletedYemekhaneRezervasyon);
                        return ServiceResponseBuilder.SuccessResponse<YemekhaneRezervasyonIptalResponsetDTO>(deletedYemekhaneRezervasyonResponsetDTO);
                    }
                    else
                    {
                        return ServiceResponseBuilder.FailResponse<YemekhaneRezervasyonIptalResponsetDTO>("Yemekhane Rezervasyonu Silinemedi");
                    }
                }
                return ServiceResponseBuilder.FailResponse<YemekhaneRezervasyonIptalResponsetDTO>(result.Errors[0].ErrorMessage);

            }
            catch (Exception ex)
            {

                throw new Exception("Yemekhane Rezervasyon Iptal İşleminde Hata", ex);
            }
        }

        public ServiceResultResponse<List<YemekhaneRezervasyonListeleResponsetDTO>> YemekhaneRezervasyonListele(YemekhaneRezervasyonListeleRequestDTO entity)
        {
            try
            {

                var responseEntities = new List<YemekhaneRezervasyonListeleResponsetDTO>();

                var validator = new YemekhaneRezervasyonListeleValidator();
                var result = validator.Validate(entity);
                if (result.IsValid)
                {
                    var succesRezervasyonlar = yemekhaneRepository.GetAll(x => x.OgrenciId.Equals(entity.OgrenciId));
                    foreach (var succesRezervasyon in succesRezervasyonlar)
                    {
                        if (succesRezervasyon.Status == 1)
                        {

                            var responseEntity = mapper.Map<YemekhaneRezervasyonListeleResponsetDTO>(succesRezervasyon);

                            responseEntities.Add(responseEntity);

                        }

                    }
                    return ServiceResponseBuilder.SuccessResponse<List<YemekhaneRezervasyonListeleResponsetDTO>>(responseEntities);

                }
                return ServiceResponseBuilder.FailResponse<List<YemekhaneRezervasyonListeleResponsetDTO>>(result.Errors[0].ErrorMessage);

            }
            catch (Exception ex)
            {

                throw new Exception("Yemekhane Rezervasyon Listeleme İşleminde Hata", ex);
            }
        }

        public ServiceResultResponse<YemekhaneRezervasyonYapResponsetDTO> YemekhaneRezervasyonYap(YemekhaneRezervasyonYapRequestDTO entity)
        {
            try
            {
                entity.IsRandevu = 1;
                var validator = new YemekhaneRezervasyonYapValidator();
                var result = validator.Validate(entity);
                if (result.IsValid)
                {
                    var succesRezervasyon = yemekhaneRepository.Add(mapper.Map<Yemekhane>(entity));
                    if (succesRezervasyon != null)
                    {
                        var responseEntity = mapper.Map<YemekhaneRezervasyonYapResponsetDTO>(succesRezervasyon);
                        return ServiceResponseBuilder.SuccessResponse<YemekhaneRezervasyonYapResponsetDTO>(responseEntity);
                    }
                    else
                    {
                        return ServiceResponseBuilder.FailResponse<YemekhaneRezervasyonYapResponsetDTO>("Yemekhane Rezervasyon Eklenemedi.");
                    }
                   
                }

                return ServiceResponseBuilder.FailResponse<YemekhaneRezervasyonYapResponsetDTO>(result.Errors[0].ErrorMessage);
            }
            catch (Exception ex)
            {

                throw new Exception("Yemekhane Rezervasyon Ekleme İşleminde Hata", ex);
            }
        }

        public ServiceResultResponse<List<YemekhaneRezervasyonMusaitListeleResponsetDTO>> YemekhaneRezervasyonMusaitListele(YemekhaneRezervasyonMusaitListeleRequestDTO entity)
        {
            try
            {

                var responseEntities = new List<YemekhaneRezervasyonMusaitListeleResponsetDTO>();

                var validator = new YemekhaneRezervasyonMusaitListeleValidator();
                var result = validator.Validate(entity);
                if (result.IsValid)
                {
                    var succesRezervasyonlar = yemekhaneRepository.GetAll(x => x.IsRandevu.Equals(0));
                    foreach (var succesRezervasyon in succesRezervasyonlar)
                    {
                        if (succesRezervasyon.Status == 1)
                        {

                            var responseEntity = mapper.Map<YemekhaneRezervasyonMusaitListeleResponsetDTO>(succesRezervasyon);

                            responseEntities.Add(responseEntity);

                        }

                    }
                    return ServiceResponseBuilder.SuccessResponse<List<YemekhaneRezervasyonMusaitListeleResponsetDTO>>(responseEntities);

                }
                return ServiceResponseBuilder.FailResponse<List<YemekhaneRezervasyonMusaitListeleResponsetDTO>>(result.Errors[0].ErrorMessage);

            }
            catch (Exception ex)
            {

                throw new Exception("Yemekhane Müsait Rezervasyon Listeleme İşleminde Hata", ex);
            }
        }
    }
}
