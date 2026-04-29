FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# 1. Copiamos todo lo que hay en la carpeta actual
COPY . .

# 2. Publicamos buscando el archivo .csproj donde sea que esté en esta carpeta
RUN dotnet publish *.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# 3. Traemos los archivos publicados
COPY --from=build /app/out .

# 4. Ejecutamos la DLL (asegúrate de que el nombre sea este)
ENTRYPOINT ["dotnet", "CitasMedicas.Web.dll"]
