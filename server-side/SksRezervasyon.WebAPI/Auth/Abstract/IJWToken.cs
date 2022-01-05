using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace SksRezervasyon.WebAPI.Auth.Abstract
{
    public interface IJWToken
    {
        string GenerateJSONWebToken(int id);
        int GetId(IEnumerable<Claim> claims);
        JwtSecurityToken Verify(string jwt);
    }
}
