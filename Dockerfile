FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiamos absolutamente todo el contenido del repo
COPY . .

# Restauramos las dependencias buscando cualquier archivo .slnx o .sln
RUN dotnet restore *.slnx || dotnet restore *.sln

# Publicamos la API apuntando directamente a la carpeta donde está el proyecto
RUN dotnet publish API_CitasMedicas/API_CitasMedicas.csproj -c Release -o out

# Imagen de ejecución final
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Comando para arrancar la API
ENTRYPOINT ["dotnet", "API_CitasMedicas.dll"]
