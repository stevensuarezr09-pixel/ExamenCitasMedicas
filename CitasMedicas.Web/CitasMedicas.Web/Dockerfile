FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 1. Copiamos todo el contenido
COPY . .

# 2. TRUCO FINAL: Movemos la API a donde la Web la busca
# Esto soluciona el error "../../API_CitasMedicas" de una vez por todas
RUN mkdir -p /API_CitasMedicas && cp -r API_CitasMedicas/* /API_CitasMedicas/

# 3. Restauramos y Publicamos
RUN dotnet restore "CitasMedicas.Web/CitasMedicas.Web/CitasMedicas.Web.csproj"
RUN dotnet publish "CitasMedicas.Web/CitasMedicas.Web/CitasMedicas.Web.csproj" -c Release -o /app/publish

# 4. Imagen final
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "CitasMedicas.Web.dll"]
