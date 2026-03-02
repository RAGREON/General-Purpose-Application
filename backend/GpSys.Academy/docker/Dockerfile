# Stage 0: EF tools
FROM mcr.microsoft.com/dotnet/sdk:9.0 as ef-tools
RUN dotnet tool install --global dotnet-ef

# Stage 1: Publish
FROM mcr.microsoft.com/dotnet/sdk:9.0 as publish
WORKDIR /src

COPY ["../src/GpSys.Academy.WebApi/GpSys.Academy.WebApi.csproj", "./GpSys.Academy"]
COPY ["../src/GpSys.Academy.Application/GpSys.Academy.Application.csproj", "./GpSys.Academy"]
COPY ["../src/GpSys.Academy.Infrastructure/GpSys.Academy.Infrastructure.csproj", "./GpSys.Academy"]
COPY ["../src/GpSys.Academy.Domain/GpSys.Academy.Domain.csproj", "./GpSys.Academy"]

RUN dotnet restore ./GpSys.Academy.WebApi/GpSys.Academy.WebApi.csproj --runtime linux-x64

COPY ["../src/", "."]
RUN dotnet publish --no-restore \
  "../src/GpSys.Academy.WebApi/GpSys.Academy.WebApi.csproj" \
  -c Release \
  -o /app/publish \
  -p:UseAppHost=false

# Stage 2: Runtime
FROM mcr.microsoft.com/aspnet/sdk:9.0 as publish
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lab.dll"]