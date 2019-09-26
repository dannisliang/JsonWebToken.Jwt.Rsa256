# JsonWebToken.Jwt.Rsa256
Generate a Json Web Token (JWT) from a OpenSSL generated RSA256 private key

This application will help you generate a JSON Web Token (JWT) from a OpenSSL generated RSA256 key.

To generate a private key from OpenSSL execute the following commands:

$ openssl genpkey -algorithm RSA -out privateKey.pem -pkeyopt rsa_keygen_bits:4096
$ openssl rsa -in privateKey.pem -pubout -out publicKey.pem

From there you can either read the PEM file in via:

string privateKey = PemHelper.GetRSAProviderFromPemFile('FileName.PEM')

-or-

string privateKey = PemHelper.GetRSAProviderFromPem(strPrivateKey)

Email jonraynor@outlook.com for any questions.
