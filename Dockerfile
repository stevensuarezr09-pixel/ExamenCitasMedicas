FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia todo el contenido del repositorio para que vea las subcarpetas
COPY . ./

# Restaurar usando el archivo de solución específico
RUN dotnet restore API_CitasMedicas.slnx

# Publicar el proyecto de la API apuntando al csproj correcto
RUN dotnet publish API_CitasMedicas/API_CitasMedicas.csproj -c Release -o out

# Imagen de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Asegúrate de que el nombre de la DLL sea este (puedes verificarlo en tu carpeta bin local)
ENTRYPOINT ["dotnet", "API_CitasMedicas.dll"]
