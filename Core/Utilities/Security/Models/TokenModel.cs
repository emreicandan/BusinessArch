﻿namespace Core.Utilities.Security.JWT;

public class TokenModel
{
    public string Token { get; set; }
    public DateTime ExpirationDate { get; set; }
}
