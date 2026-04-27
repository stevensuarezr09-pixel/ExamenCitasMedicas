FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 1. Subimos dos niveles para copiar TODO el repositorio (Web y API)
COPY . .

# 2. Restauramos apuntando al archivo que está en la misma carpeta
RUN dotnet restore "CitasMedicas.Web/CitasMedicas.Web/CitasMedicas.Web.csproj"

# 3. Publicamos
RUN dotnet publish "CitasMedicas.Web/CitasMedicas.Web/CitasMedicas.Web.csproj" -c Release -o /app/publish

# 4. Imagen final
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "CitasMedicas.Web.dll"]
