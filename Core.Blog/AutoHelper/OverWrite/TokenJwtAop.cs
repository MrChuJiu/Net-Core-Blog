using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Blog.AutoHelper.OverWrite
{
    public static class TokenJwtAop
    {
        public static TokenModelJWT GetToken(HttpContext httpContext) {
            if (!httpContext.Request.Headers.ContainsKey("Authorization"))
                return null;
            var tokenHeader = httpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            TokenModelJWT tm = JwtHelper.SerializeJWT(tokenHeader);
            return tm;
        }
    }
}
