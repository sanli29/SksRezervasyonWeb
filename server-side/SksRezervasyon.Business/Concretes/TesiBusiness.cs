using AutoMapper;
using SksRezervasyon.Business.Abstract;
using SksRezervasyon.Business.DTO.Tesi;
using SksRezervasyon.Business.FluentValidation.Tesi;
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
    public class TesiBusiness : IDisposable, ITesiBusiness
    {
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

        private readonly ITesiRepository tesiRepository;
        private readonly IMapper mapper;

        public TesiBusiness(IMapper mapper, ITesiRepository tesiRepository)
        {
            this.mapper = mapper;
            this.tesiRepository = tesiRepository;
        }
        public ServiceResultResponse<TesiRezervasyonIptalResponsetDTO> TesiRezervasyonIptal(TesiRezervasyonIptalRequestDTO entity)
        {
            try
            {
                var validator = new TesiRezervasyonIptalValidator();
                var result = validator.Validate(entity);
                if (result.IsValid)
                {
                    var deletedTesiRezervasyon = tesiRepository.Delete(entity.TesisId);
                    if (deletedTesiRezervasyon != null)
                    {
                        var deletedTesiRezervasyonResponsetDTO = mapper.Map<TesiRezervasyonIptalResponsetDTO>(deletedTesiRezervasyon);
                        return ServiceResponseBuilder.SuccessResponse<TesiRezervasyonIptalResponsetDTO>(deletedTesiRezervasyonResponsetDTO);
                    }
                    else
                    {
                        return ServiceResponseBuilder.FailResponse<TesiRezervasyonIptalResponsetDTO>("Tesi Rezervasyonu Silinemedi");
                    }
                }
                return ServiceResponseBuilder.FailResponse<TesiRezervasyonIptalResponsetDTO>(result.Errors[0].ErrorMessage);

            }
            catch (Exception ex)
            {

                throw new Exception("Tesi Rezervasyon Iptal İşleminde Hata", ex);
            }
        }

        public ServiceResultResponse<List<TesiRezervasyonListeleResponsetDTO>> TesiRezervasyonListele(TesiRezervasyonListeleRequestDTO entity)
        {
            try
            {

                var responseEntities = new List<TesiRezervasyonListeleResponsetDTO>();

                var validator = new TesiRezervasyonListeleValidator();
                var result = validator.Validate(entity);
                if (result.IsValid)
                {
                    var succesRezervasyonlar = tesiRepository.GetAll(x => x.OgrenciId.Equals(entity.OgrenciId));
                    foreach (var succesRezervasyon in succesRezervasyonlar)
                    {
                        if (succesRezervasyon.Status == 1)
                        {

                            var responseEntity = mapper.Map<TesiRezervasyonListeleResponsetDTO>(succesRezervasyon);

                            responseEntities.Add(responseEntity);

                        }

                    }
                    return ServiceResponseBuilder.SuccessResponse<List<TesiRezervasyonListeleResponsetDTO>>(responseEntities);

                }
                return ServiceResponseBuilder.FailResponse<List<TesiRezervasyonListeleResponsetDTO>>(result.Errors[0].ErrorMessage);

            }
            catch (Exception ex)
            {

                throw new Exception("Tesi Rezervasyon Listeleme İşleminde Hata", ex);
            }
        }

        public ServiceResultResponse<TesiRezervasyonYapResponsetDTO> TesiRezervasyonYap(TesiRezervasyonYapRequestDTO entity)
        {
            try
            {
                var validator = new TesiRezervasyonYapValidator();
                var result = validator.Validate(entity);
                if (result.IsValid)
                {
                    var succesRezervasyon = tesiRepository.Add(mapper.Map<Tesi>(entity));
                    if (succesRezervasyon != null)
                    {
                        var responseEntity = mapper.Map<TesiRezervasyonYapResponsetDTO>(succesRezervasyon);
                        return ServiceResponseBuilder.SuccessResponse<TesiRezervasyonYapResponsetDTO>(responseEntity);
                    }
                    else
                    {
                        return ServiceResponseBuilder.FailResponse<TesiRezervasyonYapResponsetDTO>("Tesi Rezervasyon Eklenemedi.");
                    }
                   
                }

                return ServiceResponseBuilder.FailResponse<TesiRezervasyonYapResponsetDTO>(result.Errors[0].ErrorMessage);
            }
            catch (Exception ex)
            {

                throw new Exception("Tesi Rezervasyon Ekleme İşleminde Hata", ex);
            }
        }

        public ServiceResultResponse<TesiRezervasyonMusaitListeleResponsetDTO> TesiRezervasyonMusaitListele(TesiRezervasyonMusaitListeleRequestDTO entity)
        {
            try
            {

                List<string> defaultBaslangicSaati = new List<string> { "9:00-10:00", "10:00-11:00", "11:00-12:00", "12:00-13:00", "13:00-14:00", "14:00-15:00", "15:00-16:00", "16:00-17:00", "17:00-18:00", "18:00-19:00", "19:00-20:00" };


                var responseEntities = new TesiRezervasyonMusaitListeleResponsetDTO();

                var validator = new TesiRezervasyonMusaitListeleValidator();
                var result = validator.Validate(entity);
                if (result.IsValid)
                {
                    var succesRezervasyonlar = tesiRepository.GetAll(x => x.Tarih.Equals(entity.Tarih) && x.TesisTur.Equals(entity.TesisTur));
                    foreach (var succesRezervasyon in succesRezervasyonlar)
                    {
                        if (succesRezervasyon.Status == 1)
                        {
                            defaultBaslangicSaati.Remove(succesRezervasyon.BaslangicSaati);
                        }
                    }
                    responseEntities.BaslangicSaati = defaultBaslangicSaati;
                    return ServiceResponseBuilder.SuccessResponse<TesiRezervasyonMusaitListeleResponsetDTO>(responseEntities);
                }
                return ServiceResponseBuilder.FailResponse<TesiRezervasyonMusaitListeleResponsetDTO>(result.Errors[0].ErrorMessage);
            }
            catch (Exception ex)
            {
                throw new Exception("Tesi Müsait Rezervasyon Listeleme İşleminde Hata", ex);
            }
        }

    }
}
