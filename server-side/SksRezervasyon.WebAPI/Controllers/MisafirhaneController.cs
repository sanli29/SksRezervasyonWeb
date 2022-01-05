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
using SksRezervasyon.Business.DTO.Misafirhane;

namespace SksRezervasyon.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [OgrenciAuthorization]
    public class MisafirhaneController : ControllerBase
    {

        private readonly IMisafirhaneBusiness misafirhaneBusiness;
        private readonly IJWToken _JWToken;


        public MisafirhaneController(IMisafirhaneBusiness misafirhaneBusiness, IJWToken _JWToken)
        {
            this.misafirhaneBusiness = misafirhaneBusiness;
            this._JWToken = _JWToken;
        }

        [HttpPost]
        public ServiceResultResponse<MisafirhaneRezervasyonIptalResponsetDTO> MisafirhaneRezervasyonIptal(MisafirhaneRezervasyonIptalRequestDTO entity)
        {
            try
            {

                Logger.Debug("MisafirhaneRezervasyonIptal Started" + JsonConvert.SerializeObject(entity));
                var response = misafirhaneBusiness.MisafirhaneRezervasyonIptal(entity);
                Logger.Debug("MisafirhaneRezervasyonIptal" + JsonConvert.SerializeObject(response));
                return response;

            }
            catch (Exception ex)
            {
                throw new Exception("MisafirhaneRezervasyonIptal işleminde hata", ex);
            }
        }

        [HttpPost]
        public ServiceResultResponse<List<MisafirhaneRezervasyonListeleResponsetDTO>> MisafirhaneRezervasyonListele(MisafirhaneRezervasyonListeleRequestDTO entity)
        {
            try
            {

                Logger.Debug("MisafirhaneRezervasyonListele Started" + JsonConvert.SerializeObject(entity));
                int idClaim = _JWToken.GetId(_JWToken.Verify(Request.Cookies["X-Access-Token"]).Claims);
                entity.OgrenciId = idClaim;
                var response = misafirhaneBusiness.MisafirhaneRezervasyonListele(entity);
                Logger.Debug("MisafirhaneRezervasyonListele" + JsonConvert.SerializeObject(response));
                return response;

            }
            catch (Exception ex)
            {
                throw new Exception("MisafirhaneRezervasyonListele işleminde hata", ex);
            }
        }

        [HttpPost]
        public ServiceResultResponse<MisafirhaneRezervasyonMusaitListeleResponsetDTO> MisafirhaneRezervasyonMusaitListele(MisafirhaneRezervasyonMusaitListeleRequestDTO entity)
        {
            try
            {

                Logger.Debug("MisafirhaneRezervasyonMusaitListele Started" + JsonConvert.SerializeObject(entity));
                var response = misafirhaneBusiness.MisafirhaneRezervasyonMusaitListele(entity);
                Logger.Debug("MisafirhaneRezervasyonMusaitListele" + JsonConvert.SerializeObject(response));
                return response;

            }
            catch (Exception ex)
            {
                throw new Exception("MisafirhaneRezervasyonMusaitListele işleminde hata", ex);
            }
        }

        [HttpPost]
        public ServiceResultResponse<MisafirhaneRezervasyonYapResponsetDTO> MisafirhaneRezervasyonYap(MisafirhaneRezervasyonYapRequestDTO entity)
        {
            try
            {

                Logger.Debug("MisafirhaneRezervasyonYap Started" + JsonConvert.SerializeObject(entity));
                int idClaim = _JWToken.GetId(_JWToken.Verify(Request.Cookies["X-Access-Token"]).Claims);
                entity.OgrenciId = idClaim;
                var response = misafirhaneBusiness.MisafirhaneRezervasyonYap(entity);
                Logger.Debug("MisafirhaneRezervasyonYap" + JsonConvert.SerializeObject(response));
                return response;

            }
            catch (Exception ex)
            {
                throw new Exception("MisafirhaneRezervasyonYap işleminde hata", ex);
            }
        }
       
    }
}
