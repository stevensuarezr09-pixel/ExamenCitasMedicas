FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 1. Copiamos TODO desde la raíz para que vea la API
COPY . .

# 2. Forzamos la publicación ignorando errores de rutas relativas viejas
RUN dotnet publish "CitasMedicas.Web/CitasMedicas.Web/CitasMedicas.Web.csproj" -c Release -o /app/publish /p:RestorePackages=false

# 3. Imagen final
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "CitasMedicas.Web.dll"]
