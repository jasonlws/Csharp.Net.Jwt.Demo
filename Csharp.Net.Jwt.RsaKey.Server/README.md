Build Docker Image

```bash
$ docker build -t jasonlws/csharp.net.jwt.demo:rsa-server .
```

Docker Run (Windows CMD)

```bash
$ docker run -d -p 55210:8080 -e ASPNETCORE_ENVIRONMENT=Development -e TokenExpires=60000 -e Issuer=jasonlws -e Audience=admin -e RsaKeyPath=/app/Certs/jwt-rsa256-privateKey.pem -v %cd%/Certs/jwt-rsa256-privateKey.pem:/app/Certs/jwt-rsa256-privateKey.pem --name csharp.net.jwt.demo.rsa.server jasonlws/csharp.net.jwt.demo:rsa-server
```

Docker Run (Windows PowerShell / Linux)

```bash
$ docker run -d -p 55210:8080 -e ASPNETCORE_ENVIRONMENT=Development -e TokenExpires=60000 -e Issuer=jasonlws -e Audience=admin -e RsaKeyPath=/app/Certs/jwt-rsa256-privateKey.pem -v ${pwd}/Certs/jwt-rsa256-privateKey.pem:/app/Certs/jwt-rsa256-privateKey.pem --name csharp.net.jwt.demo.rsa.server jasonlws/csharp.net.jwt.demo:rsa-server
```