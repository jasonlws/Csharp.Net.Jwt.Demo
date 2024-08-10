Build Docker Image

```bash
$ docker build -t jasonlws/csharp.net.jwt.demo:sym-client .
```

Docker Run (Windows CMD)

```bash
$ docker run -d -p 55201:8080 -e ASPNETCORE_ENVIRONMENT=Development -e Issuers=jasonlws -e Audiences=admin -e SymmetricKeyPath=/app/Certs/jwt-symmetric-key.key -v %cd%/Certs/jwt-symmetric-key.key:/app/Certs/jwt-symmetric-key.key --name csharp.net.jwt.demo.sym.client jasonlws/csharp.net.jwt.demo:sym-client
```

Docker Run (Windows PowerShell / Linux)

```bash
$ docker run -d -p 55201:8080 -e ASPNETCORE_ENVIRONMENT=Development -e Issuers=jasonlws -e Audiences=admin -e SymmetricKeyPath=/app/Certs/jwt-symmetric-key.key -v ${pwd}/Certs/jwt-symmetric-key.key:/app/Certs/jwt-symmetric-key.key --name csharp.net.jwt.demo.sym.client jasonlws/csharp.net.jwt.demo:sym-client
```