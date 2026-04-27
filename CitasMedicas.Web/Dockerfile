FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# 1. Copiamos todo el contenido de la carpeta
COPY . .

# 2. Especificamos el nombre del archivo .csproj para que no haya pérdida
# ¡OJO! Asegúrate de que las mayúsculas sean iguales a tu archivo real
RUN dotnet publish "CitasMedicas.Web.csproj" -c Release -o out

# 3. Imagen de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Aquí también especificamos la DLL exacta
ENTRYPOINT ["dotnet", "CitasMedicas.Web.dll"]
