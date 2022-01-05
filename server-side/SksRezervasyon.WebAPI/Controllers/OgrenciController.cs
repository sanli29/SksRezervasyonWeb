
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SksRezervasyon.Business.Concretes;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using SksRezervasyon.Business.DTO;
using AutoMapper;
using SksRezervasyon.Business.ServiceResponse;
using SksRezervasyon.WebAPI.Auth.Abstract;
using SksRezervasyon.Business.Abstract;

using Microsoft.Extensions.Logging;
using System.Reflection;
using System.IO;
using log4net.Repository;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;
using SksRezervasyon.WebAPI.Auth;
using System.Net;
using System.Net.Mail;
using SksRezervasyon.Business.FluentValidation.Ogrenci;
using SksRezervasyon.Business.DTO.Ogrenci;

namespace SksRezervasyon.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OgrenciController : ControllerBase
    {

        private readonly IOgrenciBusiness ogrenciBusiness;
        private readonly IJWToken _JWToken;

        public OgrenciController(IOgrenciBusiness ogrenciBusiness, IJWToken _JWToken)
        {
            this.ogrenciBusiness = ogrenciBusiness;
            this._JWToken = _JWToken;
        }

        [HttpPost]
        public ServiceResultResponse<OgrenciLoginResponsetDTO> Login([FromBody] OgrenciLoginRequestDTO entity)
        {
            try
            {

                Logger.Debug("Login Started" + JsonConvert.SerializeObject(entity));
                var loginResponsetDTO = ogrenciBusiness.Login(entity);

                if (loginResponsetDTO.success)
                {
                    var tokenString = _JWToken.GenerateJSONWebToken(loginResponsetDTO.data.OgrenciId);
                    Response.Cookies.Append("X-Access-Token", tokenString, new CookieOptions() { HttpOnly = true, Expires = DateTime.UtcNow.AddDays(5) });
                }
                Logger.Debug("Login Finished" + JsonConvert.SerializeObject(loginResponsetDTO));
                return loginResponsetDTO;


            }
            catch (Exception ex)
            {
                throw new Exception("Login İşleminde Hata", ex);
            }
        }

        [HttpPost]
        public ServiceResultResponse<OgrenciRegisterResponsetDTO> Register([FromBody] OgrenciRegisterRequestDTO entity)
        {
            try
            {

                Logger.Debug("Register Started" + JsonConvert.SerializeObject(entity));

                var registerResponsetDTO = ogrenciBusiness.Register(entity);

                Logger.Debug("Register Finished" + JsonConvert.SerializeObject(registerResponsetDTO));
                return registerResponsetDTO;


            }
            catch (Exception ex)
            {
                throw new Exception("Register İşleminde Hata", ex);
            }
        }


        [HttpPost]
        public ServiceResultResponse<OgrenciLogoutResponsetDTO> Logout([FromBody] OgrenciLogoutRequestDTO entity)
        {
            try
            {
                Logger.Debug("Logout Started");
                var response = new OgrenciLogoutResponsetDTO();
                foreach (var cookie in Request.Cookies.Keys)
                {
                    Response.Cookies.Delete(cookie);
                }

                var result = ServiceResponseBuilder.SuccessResponse<OgrenciLogoutResponsetDTO>(response);
                Logger.Debug("Logout Finished" + JsonConvert.SerializeObject(result));
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Logout İşleminde Hata", ex);
            }
        }

    }
}
