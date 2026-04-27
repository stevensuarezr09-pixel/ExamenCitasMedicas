FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# 1. Copiamos todo el contenido
COPY . .

# 2. EL TRUCO MAESTRO: Creamos la carpeta y el archivo faltante para engañar al compilador
RUN mkdir -p API_CitasMedicas/App_Data && touch API_CitasMedicas/App_Data/ClinicaMedica.mdf

# 3. Restauramos dependencias
RUN dotnet restore $(find . -name "*.csproj" | head -n 1)

# 4. Publicamos el proyecto
RUN dotnet publish $(find . -name "*.csproj" | head -n 1) -c Release -o out

# 5. Imagen de ejecución final
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# 6. Arrancamos la DLL
ENTRYPOINT ["dotnet", "API_CitasMedicas.dll"]
