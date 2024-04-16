#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#WORKDIR /app
EXPOSE 80
EXPOSE 443

#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /src
COPY ["MegaLTAPI1.csproj", "."]
COPY ["../BLLayer/BLLayer.csproj", "../BLLayer/"]
COPY ["../BusinessEntities/BusinessEntities.csproj", "../BusinessEntities/"]
COPY ["../DALayer/DALayer.csproj", "../DALayer/"]
COPY ["../ModelDTOs/ModelDTOs.csproj", "../ModelDTOs/"]
RUN dotnet restore "./MegaLTAPI1.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "MegaLTAPI1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MegaLTAPI1.csproj" -c Release -o /app/publish /p:UseAppHost=false

#FROM base AS final
# Use the official .NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MegaLTAPI1.dll"]
