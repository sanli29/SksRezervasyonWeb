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
using SksRezervasyon.Business.DTO.Tesi;

namespace SksRezervasyon.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [OgrenciAuthorization]
    public class TesiController : ControllerBase
    {

        private readonly ITesiBusiness tesiBusiness;
        private readonly IJWToken _JWToken;


        public TesiController(ITesiBusiness tesiBusiness, IJWToken _JWToken)
        {
  
            this.tesiBusiness = tesiBusiness;
            this._JWToken = _JWToken;
        }

        [HttpPost]
        public ServiceResultResponse<TesiRezervasyonIptalResponsetDTO> TesiRezervasyonIptal(TesiRezervasyonIptalRequestDTO entity)
        {
            try
            {

                Logger.Debug("TesiRezervasyonIptal Started" + JsonConvert.SerializeObject(entity));
                var response = tesiBusiness.TesiRezervasyonIptal(entity);
                Logger.Debug("TesiRezervasyonIptal" + JsonConvert.SerializeObject(response));
                return response;

            }
            catch (Exception ex)
            {
                throw new Exception("TesiRezervasyonIptal işleminde hata", ex);
            }
        }

        [HttpPost]
        public ServiceResultResponse<List<TesiRezervasyonListeleResponsetDTO>> TesiRezervasyonListele(TesiRezervasyonListeleRequestDTO entity)
        {
            try
            {

                Logger.Debug("TesiRezervasyonListele Started" + JsonConvert.SerializeObject(entity));
                int idClaim = _JWToken.GetId(_JWToken.Verify(Request.Cookies["X-Access-Token"]).Claims);
                entity.OgrenciId = idClaim;
                var response = tesiBusiness.TesiRezervasyonListele(entity);
                Logger.Debug("TesiRezervasyonListele" + JsonConvert.SerializeObject(response));
                return response;

            }
            catch (Exception ex)
            {
                throw new Exception("TesiRezervasyonListele işleminde hata", ex);
            }
        }

        [HttpPost]
        public ServiceResultResponse<TesiRezervasyonMusaitListeleResponsetDTO> TesiRezervasyonMusaitListele(TesiRezervasyonMusaitListeleRequestDTO entity)
        {
            try
            {

                Logger.Debug("TesiRezervasyonMusaitListele Started" + JsonConvert.SerializeObject(entity));
                var response = tesiBusiness.TesiRezervasyonMusaitListele(entity);
                Logger.Debug("TesiRezervasyonMusaitListele" + JsonConvert.SerializeObject(response));
                return response;

            }
            catch (Exception ex)
            {
                throw new Exception("TesiRezervasyonMusaitListele işleminde hata", ex);
            }
        }

        [HttpPost]
        public ServiceResultResponse<TesiRezervasyonYapResponsetDTO> TesiRezervasyonYap(TesiRezervasyonYapRequestDTO entity)
        {
            try
            {

                Logger.Debug("TesiRezervasyonYap Started" + JsonConvert.SerializeObject(entity));
                int idClaim = _JWToken.GetId(_JWToken.Verify(Request.Cookies["X-Access-Token"]).Claims);
                entity.OgrenciId = idClaim;
                var response = tesiBusiness.TesiRezervasyonYap(entity);
                Logger.Debug("TesiRezervasyonYap" + JsonConvert.SerializeObject(response));
                return response;

            }
            catch (Exception ex)
            {
                throw new Exception("TesiRezervasyonYap işleminde hata", ex);
            }
        }
       
    }
}
