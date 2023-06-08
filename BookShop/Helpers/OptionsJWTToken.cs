using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BookShop.Helpers;

public static class OptionsJWTToken
{
    public static TokenValidationParameters Create(WebApplicationBuilder builder)
    {
        var secretKey = builder.Configuration.GetSection("JWTSettings:SecretKey").Value;
        var issuer = builder.Configuration.GetSection("JWTSettings:Issuer").Value;
        var audience = builder.Configuration.GetSection("JWTSettings:Audience").Value;
        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        return new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = issuer,
            ValidateAudience = true,
            ValidAudience = audience,
            ValidateLifetime = true,
            IssuerSigningKey = signingKey,
            ValidateIssuerSigningKey = true
        };
    }
}
