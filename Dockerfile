FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# 1. Copiamos todo
COPY . .

# 2. Restauramos dependencias
RUN dotnet restore $(find . -name "*.csproj" | head -n 1)

# 3. PUBLICAR (AQUÍ ESTÁ EL TRUCO): 
# Agregamos un comando para que no falle si falta la base de datos .mdf
RUN dotnet publish $(find . -name "*.csproj" | head -n 1) -c Release -o out /p:PublishMetadata=false /p:CopyAllFilesToSingleFolderForMsdeploy=false

# 4. Imagen de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# 5. Arrancamos
ENTRYPOINT ["dotnet", "API_CitasMedicas.dll"]
