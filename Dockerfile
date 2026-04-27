FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia todo para que el compilador vea las dos carpetas
COPY . ./
RUN dotnet restore

# Publica la API específicamente
RUN dotnet publish API_CitasMedicas/API_CitasMedicas.csproj -c Release -o out

# Imagen de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Ejecuta la API
ENTRYPOINT ["dotnet", "API_CitasMedicas.dll"]
