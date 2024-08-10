Build Docker Image

```bash
$ docker build -t jasonlws/csharp.net.jwt.demo:sym-server . 
```

Docker Run (Windows CMD)

```bash
$ docker run -d -p 55200:8080 -e ASPNETCORE_ENVIRONMENT=Development -e TokenExpires=60000 -e Issuer=jasonlws -e Audience=admin -e SymmetricKeyPath=/app/Certs/jwt-symmetric-key.key -v %cd%/Certs/jwt-symmetric-key.key:/app/Certs/jwt-symmetric-key.key --name csharp.net.jwt.demo.sym.server jasonlws/csharp.net.jwt.demo:sym-server
```

Docker Run (Windows PowerShell / Linux)

```bash
$ docker run -d -p 55200:8080 -e ASPNETCORE_ENVIRONMENT=Development -e TokenExpires=60000 -e Issuer=jasonlws -e Audience=admin -e SymmetricKeyPath=/app/Certs/jwt-symmetric-key.key -v ${pwd}/Certs/jwt-symmetric-key.key:/app/Certs/jwt-symmetric-key.key --name csharp.net.jwt.demo.sym.server jasonlws/csharp.net.jwt.demo:sym-server
```