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
using SksRezervasyon.Business.DTO.Yemekhane;

namespace SksRezervasyon.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [OgrenciAuthorization]
    public class YemekhaneController : ControllerBase
    {

        private readonly IYemekhaneBusiness yemekhaneBusiness;
        private readonly IJWToken _JWToken;


        public YemekhaneController(IYemekhaneBusiness yemekhaneBusiness, IJWToken _JWToken)
        {

            this.yemekhaneBusiness = yemekhaneBusiness;
            this._JWToken = _JWToken;
        }

        [HttpPost]
        public ServiceResultResponse<YemekhaneRezervasyonIptalResponsetDTO> YemekhaneRezervasyonIptal(YemekhaneRezervasyonIptalRequestDTO entity)
        {
            try
            {

                Logger.Debug("YemekhaneRezervasyonIptal Started" + JsonConvert.SerializeObject(entity));
                var response = yemekhaneBusiness.YemekhaneRezervasyonIptal(entity);
                Logger.Debug("YemekhaneRezervasyonIptal" + JsonConvert.SerializeObject(response));
                return response;

            }
            catch (Exception ex)
            {
                throw new Exception("YemekhaneRezervasyonIptal işleminde hata", ex);
            }
        }

        [HttpPost]
        public ServiceResultResponse<List<YemekhaneRezervasyonListeleResponsetDTO>> YemekhaneRezervasyonListele(YemekhaneRezervasyonListeleRequestDTO entity)
        {
            try
            {

                Logger.Debug("YemekhaneRezervasyonListele Started" + JsonConvert.SerializeObject(entity));
                int idClaim = _JWToken.GetId(_JWToken.Verify(Request.Cookies["X-Access-Token"]).Claims);
                entity.OgrenciId = idClaim;
                var response = yemekhaneBusiness.YemekhaneRezervasyonListele(entity);
                Logger.Debug("YemekhaneRezervasyonListele" + JsonConvert.SerializeObject(response));
                return response;

            }
            catch (Exception ex)
            {
                throw new Exception("YemekhaneRezervasyonListele işleminde hata", ex);
            }
        }

        [HttpPost]
        public ServiceResultResponse<List<YemekhaneRezervasyonMusaitListeleResponsetDTO>> YemekhaneRezervasyonMusaitListele(YemekhaneRezervasyonMusaitListeleRequestDTO entity)
        {
            try
            {

                Logger.Debug("YemekhaneRezervasyonMusaitListele Started" + JsonConvert.SerializeObject(entity));
                var response = yemekhaneBusiness.YemekhaneRezervasyonMusaitListele(entity);
                Logger.Debug("YemekhaneRezervasyonMusaitListele" + JsonConvert.SerializeObject(response));
                return response;

            }
            catch (Exception ex)
            {
                throw new Exception("YemekhaneRezervasyonMusaitListele işleminde hata", ex);
            }
        }

        [HttpPost]
        public ServiceResultResponse<YemekhaneRezervasyonYapResponsetDTO> YemekhaneRezervasyonYap(YemekhaneRezervasyonYapRequestDTO entity)
        {
            try
            {

                Logger.Debug("YemekhaneRezervasyonYap Started" + JsonConvert.SerializeObject(entity));
                int idClaim = _JWToken.GetId(_JWToken.Verify(Request.Cookies["X-Access-Token"]).Claims);
                entity.OgrenciId = idClaim;
                var response = yemekhaneBusiness.YemekhaneRezervasyonYap(entity);
                Logger.Debug("YemekhaneRezervasyonYap" + JsonConvert.SerializeObject(response));
                return response;

            }
            catch (Exception ex)
            {
                throw new Exception("YemekhaneRezervasyonYap işleminde hata", ex);
            }
        }
       
    }
}
