﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using CelebrancyHQ.Models.DTOs.Authentication;
using CelebrancyHQ.Models.DTOs.Persons;

namespace CelebrancyHQ.Services.Authentication
{
    // SOURCE: https://referbruv.com/blog/getting-started-with-securing-apis-using-jwt-bearer-authentication-hands-on/

    /// <summary>
    /// Generates authentication tokens for CelebrancyHQ.
    /// </summary>
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Creates a new instance of TokenService.
        /// </summary>
        /// <param name="configuration">The application configuration.</param>
        public TokenService(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        /// <summary>
        /// Generates an authentication token.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>An authentication token for the specified user.</returns>
        public AuthTokenDTO Generate(PersonDTO user)
        {
            List<Claim> claims = new List<Claim>() {
                new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim (JwtRegisteredClaimNames.Email, user.EmailAddress),
                new Claim (JwtRegisteredClaimNames.NameId, user.UserId.ToString())
            };

            JwtSecurityToken token = new TokenBuilder()
                .AddAudience(this._configuration["Authentication:AuthToken:Audience"])
                .AddIssuer(this._configuration["Authentication:AuthToken:Issuer"])
                .AddExpiry(int.Parse(this._configuration["Authentication:AuthToken:Expiry"]))
                .AddKey(this._configuration["Authentication:AuthToken:Key"])
                .AddClaims(claims)
                .Build();

            string accessToken = new JwtSecurityTokenHandler()
                .WriteToken(token);

            return new AuthTokenDTO()
            {
                Token = accessToken,
                ExpiresIn = int.Parse(this._configuration["Authentication:AuthToken:Expiry"]),
                User = user
            };
        }
    }
}