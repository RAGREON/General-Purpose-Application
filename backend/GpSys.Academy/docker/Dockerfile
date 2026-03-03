# Stage 0: Restore (Cache layer)
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS restore

WORKDIR /src

COPY ["src/GpSys.Academy.WebApi/GpSys.Academy.WebApi.csproj", "src/GpSys.Academy.WebApi/GpSys.Academy.WebApi.csproj"]
COPY ["src/GpSys.Academy.Application/GpSys.Academy.Application.csproj", "src/GpSys.Academy.Application/GpSys.Academy.Application.csproj"]
COPY ["src/GpSys.Academy.Infrastructure/GpSys.Academy.Infrastructure.csproj", "src/GpSys.Academy.Infrastructure/GpSys.Academy.Infrastructure.csproj"]
COPY ["src/GpSys.Academy.Domain/GpSys.Academy.Domain.csproj", "src/GpSys.Academy.Domain/GpSys.Academy.Domain.csproj"]

RUN dotnet restore \
  "src/GpSys.Academy.WebApi/GpSys.Academy.WebApi.csproj" \
  --runtime linux-x64

# Stage 1: EF tools
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS ef-tools
RUN dotnet tool install --global dotnet-ef

# Stage 2: Publish
FROM restore AS publish
WORKDIR /src

COPY /src ./src

WORKDIR "/src/src/GpSys.Academy.WebApi/"

RUN dotnet publish --no-restore \
  -c Release \
  -o /app/publish \
  -p:UseAppHost=false

# Stage 3: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GpSys.Academy.WebApi.dll"]