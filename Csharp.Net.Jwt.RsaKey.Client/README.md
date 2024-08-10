Build Docker Image

```bash
$ docker build -t jasonlws/csharp.net.jwt.demo:rsa-client .
```

Docker Run (Windows CMD)

```bash
$ docker run -d -p 55211:8080 -e ASPNETCORE_ENVIRONMENT=Development -e Issuers=jasonlws -e Audiences=admin -e RsaKeyPath=/app/Certs/jwt-rsa256-publicKey.pem -v %cd%/Certs/jwt-rsa256-publicKey.pem:/app/Certs/jwt-rsa256-publicKey.pem --name csharp.net.jwt.demo.rsa.client jasonlws/csharp.net.jwt.demo:rsa-client
```

Docker Run (Windows PowerShell / Linux)

```bash
$ docker run -d -p 55211:8080 -e ASPNETCORE_ENVIRONMENT=Development -e Issuers=jasonlws -e Audiences=admin -e RsaKeyPath=/app/Certs/jwt-rsa256-publicKey.pem -v ${pwd}/Certs/jwt-rsa256-publicKey.pem:/app/Certs/jwt-rsa256-publicKey.pem --name csharp.net.jwt.demo.rsa.client jasonlws/csharp.net.jwt.demo:rsa-client
```