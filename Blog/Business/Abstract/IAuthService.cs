using Core.Utilities.Identities.Jwt;
using Core.Utilities.ResultTool;
using Entities.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<AccessToken> Login(UserLoginDto model);
    }
}
