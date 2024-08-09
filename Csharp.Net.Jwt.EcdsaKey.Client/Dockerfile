#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["./Csharp.Net.Jwt.EcdsaKey.Client.csproj", "Csharp.Net.Jwt.EcdsaKey.Client/"]
RUN dotnet restore "./Csharp.Net.Jwt.EcdsaKey.Client/Csharp.Net.Jwt.EcdsaKey.Client.csproj"

WORKDIR "/src/Csharp.Net.Jwt.EcdsaKey.Client"
COPY . .
RUN dotnet build "./Csharp.Net.Jwt.EcdsaKey.Client.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Csharp.Net.Jwt.EcdsaKey.Client.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final

WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Csharp.Net.Jwt.EcdsaKey.Client.dll"]

# docker build -t csharp.net.jwt.demo:ecdsa.client .
# docker run -d -p 55221:8080 -e ASPNETCORE_ENVIRONMENT=Development -e Issuers=jasonlws -e Audiences=admin -e EcdsaKeyPath=/app/Certs/jwt-prime256v1-publicKey.pem -v %cd%/Certs/jwt-prime256v1-publicKey.pem:/app/Certs/jwt-prime256v1-publicKey.pem --name csharp.net.jwt.demo.ecdsa.client csharp.net.jwt.demo:ecdsa.client