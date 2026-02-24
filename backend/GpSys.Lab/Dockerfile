# Stage 0: EF Tools
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS ef-tools
RUN dotnet tool install --global dotnet-ef

# Stage 1: Build & Publish
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["./Lab.csproj", "./"]
RUN dotnet restore "./Lab.csproj" --runtime linux-x64

COPY . .
RUN dotnet publish "Lab.csproj" \
    --configuration Release \
    --output /app/publish \
    -p:UseAppHost=false

# Stage 2: Migrate
FROM build AS migrate
COPY --from=ef-tools /root/.dotnet/tools /root/.dotnet/tools
ENV PATH="$PATH:/root/.dotnet/tools"

RUN dotnet ef migrations bundle \
    --project "Lab.csproj" \
    --configuration Release \
    --output /app/migrate \
    --runtime linux-x64 \
    --self-contained

# Stage 3: Migrate Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS migrate-runtime
WORKDIR /app
COPY --from=migrate /app/migrate .

RUN chmod +x ./migrate

ENTRYPOINT ["./migrate"]

# Stage 4: Runtime 
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS app-runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Lab.dll"]