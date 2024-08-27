#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PowerplantDispatch.API/PowerplantDispatch.API.csproj", "PowerplantDispatch.API/"]
COPY ["PowerplantDispatch.Application/PowerplantDispatch.Application.csproj", "PowerplantDispatch.Application/"]
COPY ["PowerplantDispatch.Domain/PowerplantDispatch.Domain.csproj", "PowerplantDispatch.Domain/"]
COPY ["PowerplantDispatch.Persistence/PowerplantDispatch.Persistence.csproj", "PowerplantDispatch.Persistence/"]
RUN dotnet restore "./PowerplantDispatch.API/PowerplantDispatch.API.csproj"
COPY . .
WORKDIR "/src/PowerplantDispatch.API"
RUN dotnet build "./PowerplantDispatch.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PowerplantDispatch.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PowerplantDispatch.API.dll"]