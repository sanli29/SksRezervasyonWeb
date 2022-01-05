using SksRezervasyon.Business.Abstract;
using SksRezervasyon.Business.Concretes;
using SksRezervasyon.Business.DTO.Ogrenci;
using SksRezervasyon.WebAPI.Auth.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SksRezervasyon.WebAPI.Auth
{
    [AttributeUsage(AttributeTargets.Class)]
    public class OgrenciAuthorization : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            if (filterContext != null)
            {
                var _token = filterContext.HttpContext.Request.Cookies["X-Access-Token"];
                if (_token != null)
                {
                    string authToken = _token;
                    if (authToken != null && IsValidToken(authToken, filterContext))
                    {
                        return;
                    }
                }
                filterContext.Result = new UnauthorizedResult();
            }
        }

        public bool IsValidToken(string authToken, AuthorizationFilterContext filterContext)
        {

            IJWToken _JWToken = (IJWToken)filterContext.HttpContext.RequestServices.GetService(typeof(IJWToken));
            IOgrenciBusiness ogrenciBusiness = (IOgrenciBusiness)filterContext.HttpContext.RequestServices.GetService(typeof(IOgrenciBusiness));
            var ogrenciGetByIDRequest = new OgrenciGetByIDRequestDTO();
            var token = _JWToken.Verify(authToken);
            ogrenciGetByIDRequest.OgrenciId = _JWToken.GetId(token.Claims);
            var user = ogrenciBusiness.GetById(ogrenciGetByIDRequest);

            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
