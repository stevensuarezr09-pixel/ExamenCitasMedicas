FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiamos todo el contenido del repo
COPY . .

# Buscamos el archivo .csproj automáticamente y restauramos
RUN dotnet restore $(find . -name "*.csproj" | head -n 1)

# Publicamos el proyecto buscando el archivo .csproj automáticamente
RUN dotnet publish $(find . -name "*.csproj" | head -n 1) -c Release -o out

# Imagen de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Ejecutamos la DLL (el nombre de tu proyecto)
ENTRYPOINT ["dotnet", "API_CitasMedicas.dll"]
