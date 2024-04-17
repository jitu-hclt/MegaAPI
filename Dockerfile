# Use the official .NET Core SDK image as a build environment
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

# Set the working directory in the container
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["MegaLTAPI1/MegaLTAPI1.csproj","MegaLTAPI1/" ]
COPY ["BLLayer/BLLayer.csproj","BLLayer/"]
COPY ["BusinessEntities/BusinessEntities.csproj","BusinessEntities/"]
COPY ["DALayer/DALayer.csproj","DALayer/"]
COPY ["ModelDTOs/ModelDTOs.csproj","ModelDTOs/"]

RUN dotnet restore "MegaLTAPI1/MegaLTAPI1.csproj"

# Display the contents of the current directory before copying files
RUN ls -la

# Copy the remaining source code
COPY . ./

# Display the contents of the current directory after copying files
RUN ls -la

# Build the application
RUN dotnet publish "MegaLTAPI1/MegaLTAPI1.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Use the official .NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

# Set the working directory in the container
WORKDIR /app

# Copy the published application from the build environment
COPY --from=build-env /app/publish .

# Expose the port that the application listens on
EXPOSE 80
EXPOSE 443

# Run the application
ENTRYPOINT ["dotnet", "MegaLTAPI1.dll"]
