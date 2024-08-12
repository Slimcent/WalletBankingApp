#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WalletApi/WalletApi.csproj", "WalletApi/"]
COPY ["Wallet.Logger/Wallet.Logger.csproj", "Wallet.Logger/"]
COPY ["Wallet.Services/Wallet.Services.csproj", "Wallet.Services/"]
COPY ["Wallet.Data/Wallet.Data.csproj", "Wallet.Data/"]
COPY ["Wallet.Entities/Wallet.Entities.csproj", "Wallet.Entities/"]
RUN dotnet restore "./WalletApi/WalletApi.csproj"
COPY . .
WORKDIR "/src/WalletApi"
RUN dotnet build "./WalletApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WalletApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WalletApi.dll"]