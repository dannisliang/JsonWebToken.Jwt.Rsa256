using Jose;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace JwtRsa256.Helpers
{
    class Token
    {
        public static string Generate()
        {
            var payload = new Dictionary<string, object>
            {
                { "sub", KeyHandler.subValueUser },
                { "iss", KeyHandler.issValue },
                { "iat", DateTimeOffset.UtcNow.ToUnixTimeSeconds() },
                { "exp", DateTimeOffset.UtcNow.AddMinutes(10).ToUnixTimeSeconds()}
            };

            var header = new Dictionary<string, object>
            {
                { "alg", "RS256" },
                { "typ", "JWT" }
            };

            RSACryptoServiceProvider rsaCrypto = PemHelper.GetRSAProviderFromPem(KeyHandler.privateKey);
            return JWT.Encode(payload, rsaCrypto, JwsAlgorithm.RS256, extraHeaders: header);
        }
    }
}
