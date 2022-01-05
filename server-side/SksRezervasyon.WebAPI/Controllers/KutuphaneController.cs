using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SksRezervasyon.Business.Concretes;
using SksRezervasyon.Core.Repository.Models;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using SksRezervasyon.Business.DTO;
using System.IO.Compression;
using Microsoft.Extensions.Localization;
using System.Resources;
using System.Reflection;
using System.Threading;
using SksRezervasyon.Business.ServiceResponse;
using SksRezervasyon.Business.Abstract;
using SksRezervasyon.WebAPI.Auth.Abstract;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SksRezervasyon.WebAPI.Auth;
using SksRezervasyon.Business.DTO.Kutuphane;

namespace SksRezervasyon.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [OgrenciAuthorization]
    public class KutuphaneController : ControllerBase
    {

        private readonly IKutuphaneBusiness kutuphaneBusiness;
        private readonly IJWToken _JWToken;


        public KutuphaneController(IKutuphaneBusiness kutuphaneBusiness, IJWToken _JWToken)
        {

            this.kutuphaneBusiness = kutuphaneBusiness;
            this._JWToken = _JWToken;
        }

        [HttpPost]
        public ServiceResultResponse<KutuphaneRezervasyonIptalResponsetDTO> KutuphaneRezervasyonIptal(KutuphaneRezervasyonIptalRequestDTO entity)
        {
            try
            {

                Logger.Debug("KutuphaneRezervasyonIptal Started" + JsonConvert.SerializeObject(entity));
                var response = kutuphaneBusiness.KutuphaneRezervasyonIptal(entity);
                Logger.Debug("KutuphaneRezervasyonIptal" + JsonConvert.SerializeObject(response));
                return response;

            }
            catch (Exception ex)
            {
                throw new Exception("KutuphaneRezervasyonIptal işleminde hata", ex);
            }
        }

        [HttpPost]
        public ServiceResultResponse<List<KutuphaneRezervasyonListeleResponsetDTO>> KutuphaneRezervasyonListele(KutuphaneRezervasyonListeleRequestDTO entity)
        {
            try
            {

                Logger.Debug("KutuphaneRezervasyonListele Started" + JsonConvert.SerializeObject(entity));
                int idClaim = _JWToken.GetId(_JWToken.Verify(Request.Cookies["X-Access-Token"]).Claims);
                entity.OgrenciId = idClaim;
                var response = kutuphaneBusiness.KutuphaneRezervasyonListele(entity);
                Logger.Debug("KutuphaneRezervasyonListele" + JsonConvert.SerializeObject(response));
                return response;

            }
            catch (Exception ex)
            {
                throw new Exception("KutuphaneRezervasyonListele işleminde hata", ex);
            }
        }

        [HttpPost]
        public ServiceResultResponse<KutuphaneRezervasyonMusaitListeleResponsetDTO> KutuphaneRezervasyonMusaitListele(KutuphaneRezervasyonMusaitListeleRequestDTO entity)
        {
            try
            {

                Logger.Debug("KutuphaneRezervasyonMusaitListele Started" + JsonConvert.SerializeObject(entity));
                var response = kutuphaneBusiness.KutuphaneRezervasyonMusaitListele(entity);
                Logger.Debug("KutuphaneRezervasyonMusaitListele" + JsonConvert.SerializeObject(response));
                return response;

            }
            catch (Exception ex)
            {
                throw new Exception("KutuphaneRezervasyonMusaitListele işleminde hata", ex);
            }
        }

        [HttpPost]
        public ServiceResultResponse<KutuphaneRezervasyonYapResponsetDTO> KutuphaneRezervasyonYap(KutuphaneRezervasyonYapRequestDTO entity)
        {
            try
            {

                Logger.Debug("KutuphaneRezervasyonYap Started" + JsonConvert.SerializeObject(entity));
                int idClaim = _JWToken.GetId(_JWToken.Verify(Request.Cookies["X-Access-Token"]).Claims);
                entity.OgrenciId = idClaim;
                var response = kutuphaneBusiness.KutuphaneRezervasyonYap(entity);
                Logger.Debug("KutuphaneRezervasyonYap" + JsonConvert.SerializeObject(response));
                return response;

            }
            catch (Exception ex)
            {
                throw new Exception("KutuphaneRezervasyonYap işleminde hata", ex);
            }
        }
       
    }
}
