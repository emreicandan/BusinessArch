using System;
using Core.Utilities.Security.JWT;
using Entities.DTOs;

namespace Business.Abstracts;

public interface IAuthService
{
    TokenModel SignIn(UserForLoginDTO userForLoginDto);
    TokenModel Register(UserForRegisterDTO userForRegisterDto);
}

