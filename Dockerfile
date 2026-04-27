FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# 1. Copiamos todo el contenido
COPY . .

# 2. Restauramos apuntando DIRECTAMENTE al proyecto (csproj), saltándonos el .slnx
RUN dotnet restore API_CitasMedicas/API_CitasMedicas.csproj

# 3. Publicamos el proyecto
RUN dotnet publish API_CitasMedicas/API_CitasMedicas.csproj -c Release -o out

# 4. Imagen de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# 5. Arrancamos la DLL
ENTRYPOINT ["dotnet", "API_CitasMedicas.dll"]
