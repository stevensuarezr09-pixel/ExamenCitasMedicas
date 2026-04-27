FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# 1. Copiamos absolutamente todo
COPY . .

# 2. TRUCO MAESTRO: Creamos el archivo fantasma en TODAS las rutas posibles
# Esto evita que el compilador se queje de que no lo encuentra.
RUN mkdir -p API_CitasMedicas/App_Data && touch API_CitasMedicas/App_Data/ClinicaMedica.mdf
RUN mkdir -p API_CitasMedicas/API_CitasMedicas/App_Data && touch API_CitasMedicas/API_CitasMedicas/App_Data/ClinicaMedica.mdf

# 3. Restauramos y publicamos ignorando errores de archivos faltantes
RUN dotnet restore $(find . -name "*.csproj" | head -n 1)
RUN dotnet publish $(find . -name "*.csproj" | head -n 1) -c Release -o out /p:IgnoreDeployManagedRuntimeVersion=true

# 4. Imagen de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# 5. Arrancamos (Asegúrate que el nombre de la DLL sea este)
ENTRYPOINT ["dotnet", "API_CitasMedicas.dll"]
