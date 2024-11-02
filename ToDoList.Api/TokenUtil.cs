using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace ToDoList.Api
{
    public static class TokenUtil
    {
        public static RsaSecurityKey RsaKey = new RsaSecurityKey(RSA.Create(2048)) { KeyId = "2333" };
        public static byte[] AesBytes = Encoding.UTF8.GetBytes("8mxJC8Oy0in8ytXa5+NmI5Je0hTWJ/rYfgUgh/c4P/Q=");
        public static SymmetricSecurityKey AesKey = new SymmetricSecurityKey(AesBytes) { KeyId = "123" };

        public static AuthenticationHeaderValue GetRSAJwt()
        {
            var issuer = "ExampleIssuer";
            var audience = "ExampleAudience";
            var tokenHandler = new JsonWebTokenHandler();
            var jwt = new SecurityTokenDescriptor
            {
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(RsaKey, SecurityAlgorithms.RsaSha256)
            };
            string jws = tokenHandler.CreateToken(jwt);
            var authroizationHeader = new AuthenticationHeaderValue("Bearer", jws);
            return authroizationHeader;
        }
        public static AuthenticationHeaderValue GetHSJwt()
        {
            var issuer = "ExampleIssuer";
            var audience = "ExampleAudience";
            var tokenHandler = new JsonWebTokenHandler();
            var jwt = new SecurityTokenDescriptor
            {
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(AesKey, SecurityAlgorithms.HmacSha256),

            };
            string jws = tokenHandler.CreateToken(jwt);
            var authroizationHeader = new AuthenticationHeaderValue("Bearer", jws);
            return authroizationHeader;
        }


        public static AuthenticationHeaderValue GetExpiredJwt()
        {
            var issuer = "ExampleIssuer";
            var audience = "ExampleAudience";
            var tokenHandler = new JsonWebTokenHandler();
            var jwt = new SecurityTokenDescriptor
            {
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(RsaKey, SecurityAlgorithms.RsaSha256),
                Expires = DateTime.UtcNow - TimeSpan.FromDays(1)
            };
            string jws = tokenHandler.CreateToken(jwt);
            var authroizationHeader = new AuthenticationHeaderValue("Bearer", jws);
            return authroizationHeader;
        }

        public static AuthenticationHeaderValue GetBasicAuthToken(string scheme, string username, string password)
        {
            var header = new AuthenticationHeaderValue(scheme,
                Convert.ToBase64String(Encoding.UTF8.GetBytes(username + ":" + password))
                );
            return header;
        }
    }
}
