using AutoMapper;
using SksRezervasyon.Business.Abstract;
using SksRezervasyon.Business.DTO.Misafirhane;
using SksRezervasyon.Business.FluentValidation.Misafirhane;
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
    public class MisafirhaneBusiness : IDisposable, IMisafirhaneBusiness
    {
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

        private readonly IMisafirhaneRepository misafirhaneRepository;
        private readonly IMapper mapper;

        public MisafirhaneBusiness(IMapper mapper, IMisafirhaneRepository misafirhaneRepository)
        {
            this.mapper = mapper;
            this.misafirhaneRepository = misafirhaneRepository;
        }
        public ServiceResultResponse<MisafirhaneRezervasyonIptalResponsetDTO> MisafirhaneRezervasyonIptal(MisafirhaneRezervasyonIptalRequestDTO entity)
        {
            try
            {
                var validator = new MisafirhaneRezervasyonIptalValidator();
                var result = validator.Validate(entity);
                if (result.IsValid)
                {
                    var deletedMisafirhaneRezervasyon = misafirhaneRepository.Delete(entity.MisafirhaneId);
                    if (deletedMisafirhaneRezervasyon != null)
                    {
                        var deletedMisafirhaneRezervasyonResponsetDTO = mapper.Map<MisafirhaneRezervasyonIptalResponsetDTO>(deletedMisafirhaneRezervasyon);
                        return ServiceResponseBuilder.SuccessResponse<MisafirhaneRezervasyonIptalResponsetDTO>(deletedMisafirhaneRezervasyonResponsetDTO);
                    }
                    else
                    {
                        return ServiceResponseBuilder.FailResponse<MisafirhaneRezervasyonIptalResponsetDTO>("Misafirhane Rezervasyonu Silinemedi");
                    }
                }
                return ServiceResponseBuilder.FailResponse<MisafirhaneRezervasyonIptalResponsetDTO>(result.Errors[0].ErrorMessage);

            }
            catch (Exception ex)
            {

                throw new Exception("Misafirhane Rezervasyon Iptal İşleminde Hata", ex);
            }
        }

        public ServiceResultResponse<List<MisafirhaneRezervasyonListeleResponsetDTO>> MisafirhaneRezervasyonListele(MisafirhaneRezervasyonListeleRequestDTO entity)
        {
            try
            {

                var responseEntities = new List<MisafirhaneRezervasyonListeleResponsetDTO>();

                var validator = new MisafirhaneRezervasyonListeleValidator();
                var result = validator.Validate(entity);
                if (result.IsValid)
                {
                    var succesRezervasyonlar = misafirhaneRepository.GetAll(x => x.OgrenciId.Equals(entity.OgrenciId));
                    foreach (var succesRezervasyon in succesRezervasyonlar)
                    {
                        if (succesRezervasyon.Status == 1)
                        {

                            var responseEntity = mapper.Map<MisafirhaneRezervasyonListeleResponsetDTO>(succesRezervasyon);

                            responseEntities.Add(responseEntity);

                        }

                    }
                    return ServiceResponseBuilder.SuccessResponse<List<MisafirhaneRezervasyonListeleResponsetDTO>>(responseEntities);

                }
                return ServiceResponseBuilder.FailResponse<List<MisafirhaneRezervasyonListeleResponsetDTO>>(result.Errors[0].ErrorMessage);

            }
            catch (Exception ex)
            {

                throw new Exception("Misafirhane Rezervasyon Listeleme İşleminde Hata", ex);
            }
        }

        public ServiceResultResponse<MisafirhaneRezervasyonYapResponsetDTO> MisafirhaneRezervasyonYap(MisafirhaneRezervasyonYapRequestDTO entity)
        {
            try
            {
                var validator = new MisafirhaneRezervasyonYapValidator();
                var result = validator.Validate(entity);
                if (result.IsValid)
                {
                    var succesRezervasyon = misafirhaneRepository.Add(mapper.Map<Misafirhane>(entity));
                    if (succesRezervasyon != null)
                    {
                        var responseEntity = mapper.Map<MisafirhaneRezervasyonYapResponsetDTO>(succesRezervasyon);
                        return ServiceResponseBuilder.SuccessResponse<MisafirhaneRezervasyonYapResponsetDTO>(responseEntity);
                    }
                    else
                    {
                        return ServiceResponseBuilder.FailResponse<MisafirhaneRezervasyonYapResponsetDTO>("Misafirhane Rezervasyon Eklenemedi.");
                    }
                   
                }

                return ServiceResponseBuilder.FailResponse<MisafirhaneRezervasyonYapResponsetDTO>(result.Errors[0].ErrorMessage);
            }
            catch (Exception ex)
            {

                throw new Exception("Misafirhane Rezervasyon Ekleme İşleminde Hata", ex);
            }
        }

        public ServiceResultResponse<MisafirhaneRezervasyonMusaitListeleResponsetDTO> MisafirhaneRezervasyonMusaitListele(MisafirhaneRezervasyonMusaitListeleRequestDTO entity)
        {
            try
            {

                List<string> defaultOdaTuru = new List<string> { "Standart","Deluxe","King","Aile","Ekonomi" };


                var responseEntities = new MisafirhaneRezervasyonMusaitListeleResponsetDTO();

                var validator = new MisafirhaneRezervasyonMusaitListeleValidator();
                var result = validator.Validate(entity);
                if (result.IsValid)
                {
                    var succesRezervasyonlar = misafirhaneRepository.GetAll(x => x.GirisTarihi.Equals(entity.GirisTarihi));
                    foreach (var succesRezervasyon in succesRezervasyonlar)
                    {
                        if (succesRezervasyon.Status == 1)
                        {
                            defaultOdaTuru.Remove(succesRezervasyon.OdaTuru);
                        }
                    }
                    responseEntities.OdaTuru = defaultOdaTuru;
                    return ServiceResponseBuilder.SuccessResponse<MisafirhaneRezervasyonMusaitListeleResponsetDTO>(responseEntities);
                }
                return ServiceResponseBuilder.FailResponse<MisafirhaneRezervasyonMusaitListeleResponsetDTO>(result.Errors[0].ErrorMessage);
            }
            catch (Exception ex)
            {
                throw new Exception("Tesi Müsait Rezervasyon Listeleme İşleminde Hata", ex);
            }
        }

    }
}
