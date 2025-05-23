# Consulte https://aka.ms/customizecontainer para aprender a personalizar su contenedor de depuración y cómo Visual Studio usa este Dockerfile para compilar sus imágenes para una depuración más rápida.

# Esta fase se usa cuando se ejecuta desde VS en modo rápido (valor predeterminado para la configuración de depuración)
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["./PlusTrack.API.csproj", "./"]
RUN dotnet restore ./PlusTrack.API.csproj

COPY [".","./"]
WORKDIR ./
RUN dotnet build "./PlusTrack.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./PlusTrack.API.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0
ENV ASPNETCORE_HTTP_PORTS=8085
EXPOSE 8085
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet","PlusTrack.API.dll"]
