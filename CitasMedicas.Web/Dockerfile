FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# 1. Copiamos todo lo que está en la carpeta
COPY . .

# 2. Usamos el asterisco para que encuentre el .csproj sin importar la ruta
RUN dotnet publish *.csproj -c Release -o out

# 3. Imagen de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Asegúrate de que el nombre de la DLL sea este
ENTRYPOINT ["dotnet", "CitasMedicas.Web.dll"]
