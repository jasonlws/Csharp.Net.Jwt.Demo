Build Docker Image

```bash
$ docker build -t jasonlws/csharp.net.jwt.demo:ecdsa-client .
```

Docker Run (Windows CMD)

```bash
$ docker run -d -p 55221:8080 -e ASPNETCORE_ENVIRONMENT=Development -e Issuers=jasonlws -e Audiences=admin -e EcdsaKeyPath=/app/Certs/jwt-prime256v1-publicKey.pem -v %cd%/Certs/jwt-prime256v1-publicKey.pem:/app/Certs/jwt-prime256v1-publicKey.pem --name csharp.net.jwt.demo.ecdsa.client jasonlws/csharp.net.jwt.demo:ecdsa.client
```

Docker Run (Windows PowerShell / Linux)

```bash
$ docker run -d -p 55221:8080 -e ASPNETCORE_ENVIRONMENT=Development -e Issuers=jasonlws -e Audiences=admin -e EcdsaKeyPath=/app/Certs/jwt-prime256v1-publicKey.pem -v ${pwd}/Certs/jwt-prime256v1-publicKey.pem:/app/Certs/jwt-prime256v1-publicKey.pem --name csharp.net.jwt.demo.ecdsa.client jasonlws/csharp.net.jwt.demo:ecdsa.client
```