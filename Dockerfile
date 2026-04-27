FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# 1. Copiamos todo el contenido
COPY . .

# 2. LIMPIEZA AGRESIVA: Borramos cualquier referencia a archivos .mdf o .ldf
# Usamos un comando que limpia el archivo .csproj sin importar cómo esté escrita la ruta
RUN find . -name "*.csproj" -exec sed -i '/.mdf/d' {} +
RUN find . -name "*.csproj" -exec sed -i '/.ldf/d' {} +

# 3. Restauramos dependencias
RUN dotnet restore $(find . -name "*.csproj" | head -n 1)

# 4. Publicamos el proyecto
RUN dotnet publish $(find . -name "*.csproj" | head -n 1) -c Release -o out

# 5. Imagen de ejecución final
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# 6. Comando para arrancar
ENTRYPOINT ["dotnet", "API_CitasMedicas.dll"]
