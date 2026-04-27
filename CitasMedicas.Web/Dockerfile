FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# 1. Copiamos todos los archivos que acabas de arrastrar a la carpeta
COPY . .

# 2. Publicamos el proyecto (esto crea los archivos listos para ejecución)
RUN dotnet publish -c Release -o out

# 3. Imagen final de ejecución (más ligera para Render)
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# IMPORTANTE: Revisa que el nombre del .dll sea exacto al de tu proyecto
ENTRYPOINT ["dotnet", "CitasMedicas.Web.dll"]
