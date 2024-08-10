Build Docker Image

```bash
$ docker build -t jasonlws/csharp.net.jwt.demo:ecdsa-server .
```

Docker Run (Windows CMD)

```bash
$ docker run -d -p 55220:8080 -e ASPNETCORE_ENVIRONMENT=Development -e TokenExpires=60000 -e Issuer=jasonlws -e Audience=admin -e EcdsaKeyPath=/app/Certs/jwt-prime256v1-privateKey.pem -v %cd%/Certs/jwt-prime256v1-privateKey.pem:/app/Certs/jwt-prime256v1-privateKey.pem --name csharp.net.jwt.demo.ecdsa.server jasonlws/csharp.net.jwt.demo:ecdsa-server
```

Docker Run (Windows PowerShell / Linux)

```bash
$ docker run -d -p 55220:8080 -e ASPNETCORE_ENVIRONMENT=Development -e TokenExpires=60000 -e Issuer=jasonlws -e Audience=admin -e EcdsaKeyPath=/app/Certs/jwt-prime256v1-privateKey.pem -v ${pwd}/Certs/jwt-prime256v1-privateKey.pem:/app/Certs/jwt-prime256v1-privateKey.pem --name csharp.net.jwt.demo.ecdsa.server jasonlws/csharp.net.jwt.demo:ecdsa-server
```