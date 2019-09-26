# JsonWebToken.Jwt.Rsa256
Generate a Json Web Token (JWT) from a OpenSSL generated RSA256 private key

This application will help you generate a JSON Web Token (JWT) from a OpenSSL generated RSA256 key using BouncyCastle in C#.


To generate a private key from OpenSSL execute the following commands:

            $ openssl genpkey -algorithm RSA -out privateKey.pem -pkeyopt rsa_keygen_bits:4096
            $ openssl rsa -in privateKey.pem -pubout -out publicKey.pem


From there you can either read the PEM file in via:


            RSACryptoServiceProvider rsaCrypto = PemHelper.GetRSAProviderFromPemFile('FileName.PEM')

-or-

            RSACryptoServiceProvider rsaCrypto = PemHelper.GetRSAProviderFromPem(strPrivateKey)



Full example:


            var payload = new Dictionary<string, object>
            {
                { "sub", subValue },
                { "iss", issValue },
                { "iat", DateTimeOffset.UtcNow.ToUnixTimeSeconds() },
                { "exp", DateTimeOffset.UtcNow.AddMinutes(10).ToUnixTimeSeconds()}
            };

            var header = new Dictionary<string, object>
            {
                { "alg", "RS256" },
                { "typ", "JWT" }
            };

            RSACryptoServiceProvider rsaCrypto = PemHelper.GetRSAProviderFromPem(KeyHandler.privateKey);
            string token = JWT.Encode(payload, rsaCrypto, JwsAlgorithm.RS256, extraHeaders: header);


Hope this helps someone out. It's relatively straight forward but took me a long time to get it to work properly, so I figured I'd make this repository public.


Email jonraynor@outlook.com for any questions.
