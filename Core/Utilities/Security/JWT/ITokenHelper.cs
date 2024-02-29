using System;
using System.IdentityModel.Tokens.Jwt;
using Core.Entities;

namespace Core.Utilities.Security.JWT;

public interface ITokenHelper
{
    TokenModel CreateToken(User user);
}

