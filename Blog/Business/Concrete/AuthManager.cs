using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Identities.Jwt;
using Core.Utilities.ResultTool;
using Entities.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        readonly ITokenService _tokenService;

        public AuthManager(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public IDataResult<AccessToken> Login(UserLoginDto model)
        {
            if (model.UserName == "admin" && model.Password == "qwerty")
            {
                var user = new User { UserName = model.UserName, Password = model.Password, PhoneNumber = "", Email = "" };
                var token = _tokenService.GenerateToken(user, new List<RoleClaim> { });

                return new SuccessDataResult<AccessToken>(token);
            }

            return new ErrorDataResult<AccessToken>();
        }
    }
}
