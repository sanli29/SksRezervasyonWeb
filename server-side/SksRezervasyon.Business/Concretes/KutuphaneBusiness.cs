using AutoMapper;
using SksRezervasyon.Business.Abstract;
using SksRezervasyon.Business.DTO.Kutuphane;
using SksRezervasyon.Business.FluentValidation.Kutuphane;
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
    public class KutuphaneBusiness : IDisposable, IKutuphaneBusiness
    {
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

        private readonly IKutuphaneRepository kutuphaneRepository;
        private readonly IMapper mapper;

        public KutuphaneBusiness(IMapper mapper, IKutuphaneRepository kutuphaneRepository)
        {
            this.mapper = mapper;
            this.kutuphaneRepository = kutuphaneRepository;
        }

        public ServiceResultResponse<KutuphaneRezervasyonIptalResponsetDTO> KutuphaneRezervasyonIptal(KutuphaneRezervasyonIptalRequestDTO entity)
        {
            try
            {
                var validator = new KutuphaneRezervasyonIptalValidator();
                var result = validator.Validate(entity);
                if (result.IsValid)
                {
                    var deletedKutuphaneRezervasyon = kutuphaneRepository.Delete(entity.KutuphaneId);
                    if (deletedKutuphaneRezervasyon != null)
                    {
                        var deletedKutuphaneRezervasyonResponsetDTO = mapper.Map<KutuphaneRezervasyonIptalResponsetDTO>(deletedKutuphaneRezervasyon);
                        return ServiceResponseBuilder.SuccessResponse<KutuphaneRezervasyonIptalResponsetDTO>(deletedKutuphaneRezervasyonResponsetDTO);
                    }
                    else
                    {
                        return ServiceResponseBuilder.FailResponse<KutuphaneRezervasyonIptalResponsetDTO>("Kutuphane Rezervasyonu Silinemedi");
                    }
                }
                return ServiceResponseBuilder.FailResponse<KutuphaneRezervasyonIptalResponsetDTO>(result.Errors[0].ErrorMessage);

            }
            catch (Exception ex)
            {

                throw new Exception("Kutuphane Rezervasyon Iptal İşleminde Hata", ex);
            }
        }

        public ServiceResultResponse<List<KutuphaneRezervasyonListeleResponsetDTO>> KutuphaneRezervasyonListele(KutuphaneRezervasyonListeleRequestDTO entity)
        {
            try
            {

                var responseEntities = new List<KutuphaneRezervasyonListeleResponsetDTO>();

                var validator = new KutuphaneRezervasyonListeleValidator();
                var result = validator.Validate(entity);
                if (result.IsValid)
                {
                    var succesRezervasyonlar = kutuphaneRepository.GetAll(x => x.OgrenciId.Equals(entity.OgrenciId));
                    foreach (var succesRezervasyon in succesRezervasyonlar)
                    {
                        if (succesRezervasyon.Status == 1)
                        {

                            var responseEntity = mapper.Map<KutuphaneRezervasyonListeleResponsetDTO>(succesRezervasyon);

                            responseEntities.Add(responseEntity);

                        }

                    }
                    return ServiceResponseBuilder.SuccessResponse<List<KutuphaneRezervasyonListeleResponsetDTO>>(responseEntities);

                }
                return ServiceResponseBuilder.FailResponse<List<KutuphaneRezervasyonListeleResponsetDTO>>(result.Errors[0].ErrorMessage);

            }
            catch (Exception ex)
            {

                throw new Exception("Kütüphane Rezervasyon Listeleme İşleminde Hata", ex);
            }
        }

        public ServiceResultResponse<KutuphaneRezervasyonYapResponsetDTO> KutuphaneRezervasyonYap(KutuphaneRezervasyonYapRequestDTO entity)
        {
            try
            {
                var validator = new KutuphaneRezervasyonYapValidator();
                var result = validator.Validate(entity);
                if (result.IsValid)
                {
                    var succesRezervasyon = kutuphaneRepository.Add(mapper.Map<Kutuphane>(entity));
                    if (succesRezervasyon != null)
                    {
                        var responseEntity = mapper.Map<KutuphaneRezervasyonYapResponsetDTO>(succesRezervasyon);
                        return ServiceResponseBuilder.SuccessResponse<KutuphaneRezervasyonYapResponsetDTO>(responseEntity);
                    }
                    else
                    {
                        return ServiceResponseBuilder.FailResponse<KutuphaneRezervasyonYapResponsetDTO>("Kütüphane Rezervasyon Eklenemedi.");
                    }                   
                }
                return ServiceResponseBuilder.FailResponse<KutuphaneRezervasyonYapResponsetDTO>(result.Errors[0].ErrorMessage);
            }
            catch (Exception ex)
            {
                throw new Exception("Kütüphane Rezervasyon Ekleme İşleminde Hata", ex);
            }
        }

        public ServiceResultResponse<KutuphaneRezervasyonMusaitListeleResponsetDTO> KutuphaneRezervasyonMusaitListele(KutuphaneRezervasyonMusaitListeleRequestDTO entity)
        {
          
            try
            {

                List<string> defaultBaslangicSaati = new List<string>{ "9:00-10:00", "10:00-11:00", "11:00-12:00", "12:00-13:00", "13:00-14:00", "14:00-15:00", "15:00-16:00", "16:00-17:00", "17:00-18:00", "18:00-19:00", "19:00-20:00" };


                var responseEntities = new KutuphaneRezervasyonMusaitListeleResponsetDTO();

                var validator = new KutuphaneRezervasyonMusaitListeleValidator();
                var result = validator.Validate(entity);
                if (result.IsValid)
                {
                    var succesRezervasyonlar = kutuphaneRepository.GetAll(x => x.OdaNo.Equals(entity.OdaNo) && x.Tarih.Equals(entity.Tarih));
                    foreach (var succesRezervasyon in succesRezervasyonlar)
                    {
                        if (succesRezervasyon.Status == 1)
                        {
                            defaultBaslangicSaati.Remove(succesRezervasyon.BaslangicSaati);
                        }
                    }
                    responseEntities.BaslangicSaati = defaultBaslangicSaati;
                    return ServiceResponseBuilder.SuccessResponse<KutuphaneRezervasyonMusaitListeleResponsetDTO>(responseEntities);
                }
                return ServiceResponseBuilder.FailResponse<KutuphaneRezervasyonMusaitListeleResponsetDTO>(result.Errors[0].ErrorMessage);
            }
            catch (Exception ex)
            {
                throw new Exception("Kütüphane Müsait Rezervasyon Listeleme İşleminde Hata", ex);
            }
        }

    }
}
