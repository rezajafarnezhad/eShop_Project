using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using _0_Framework.Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace _0_Framework.Application
{
    public class AuthHelper : IAuthHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public AuthViewModel CurrentAccountInfo()
        {
            var Result = new AuthViewModel();
            if (!IsAuthenticated())
            {
                return Result;
            }

            var Claims = _contextAccessor.HttpContext.User.Claims.ToList();
            Result.AccountId =long.Parse(Claims.FirstOrDefault(c => c.Type == "AccountId").Value);
            Result.RoleId =long.Parse(Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value);
            Result.UserName =Claims.FirstOrDefault(c => c.Type == "UserName").Value;
            Result.FullName =Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;

            return Result;
        }

        public string CurrentAccountRole()
        {
            if (IsAuthenticated())
            {
                return _contextAccessor.HttpContext.User.Claims.FirstOrDefault(c=>c.Type == ClaimTypes.Role).Value;
            }
            return null;
        }

        public List<int> GetPermissions()
        {

            if (!IsAuthenticated())
            {
                return new List<int>();
            }

            var Permissions = _contextAccessor.HttpContext.User.Claims
                .FirstOrDefault(c => c.Type == "permissions")?.Value;

            return JsonConvert.DeserializeObject<List<int>>(Permissions);
        }

        public bool IsAuthenticated()
        {


            return _contextAccessor.HttpContext.User.Identity.IsAuthenticated;


            //var Claims = _contextAccessor.HttpContext.User.Claims.ToList();

            //return Claims.Count > 0;

            //if (Claims.Count > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        public void SingIn(AuthViewModel account)
        {

            var permissins = JsonConvert.SerializeObject(account.Permissions);

            var claims = new List<Claim>
            {
                new Claim("AccountId", account.AccountId.ToString()),
                new Claim(ClaimTypes.Name, account.FullName),
                new Claim(ClaimTypes.Role, account.RoleId.ToString()),
                new Claim("UserName", account.UserName), // Or Use ClaimTypes.NameIdentifier
                new Claim("permissions",permissins)
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
            };

            _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

        public void SingOut()
        {
            _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
