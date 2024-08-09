#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["./Csharp.Net.Jwt.SymmetricKey.Server.csproj", "Csharp.Net.Jwt.SymmetricKey.Server/"]
RUN dotnet restore "./Csharp.Net.Jwt.SymmetricKey.Server/Csharp.Net.Jwt.SymmetricKey.Server.csproj"

WORKDIR "/src/Csharp.Net.Jwt.SymmetricKey.Server"
COPY . .
RUN dotnet build "./Csharp.Net.Jwt.SymmetricKey.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Csharp.Net.Jwt.SymmetricKey.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final

WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Csharp.Net.Jwt.SymmetricKey.Server.dll"]

# docker build -t csharp.net.jwt.demo:sym.server .
# docker run -d -p 55200:8080 -e ASPNETCORE_ENVIRONMENT=Development -e TokenExpires=60000 -e Issuer=jasonlws -e Audience=admin -e SymmetricKeyPath=/app/Certs/jwt-symmetric-key.key -v %cd%/Certs/jwt-symmetric-key.key:/app/Certs/jwt-symmetric-key.key --name csharp.net.jwt.demo.sym.server csharp.net.jwt.demo:sym.server