FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 1. Copiamos TODO el repositorio (API y Web)
COPY . .

# 2. Restauramos las dependencias de la Web
# El sistema encontrará automáticamente la API porque ya copiamos todo
RUN dotnet restore "CitasMedicas.Web/CitasMedicas.Web/CitasMedicas.Web.csproj"

# 3. Publicamos el proyecto Web
RUN dotnet publish "CitasMedicas.Web/CitasMedicas.Web/CitasMedicas.Web.csproj" -c Release -o /app/publish

# 4. Imagen final de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

# 5. Punto de entrada (Asegúrate que el nombre sea exacto)
ENTRYPOINT ["dotnet", "CitasMedicas.Web.dll"]
