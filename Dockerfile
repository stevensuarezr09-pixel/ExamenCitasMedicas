FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# 1. Copiamos todo el contenido
COPY . .

# 2. TRUCO DEFINITIVO: Eliminamos la referencia al archivo .mdf del archivo de proyecto
# Esto quita la "obligación" de copiar ese archivo inexistente.
RUN sed -i '/ClinicaMedica.mdf/d' $(find . -name "*.csproj" | head -n 1)

# 3. Restauramos dependencias
RUN dotnet restore $(find . -name "*.csproj" | head -n 1)

# 4. Publicamos el proyecto (sin archivos que sobren)
RUN dotnet publish $(find . -name "*.csproj" | head -n 1) -c Release -o out

# 5. Imagen de ejecución final
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# 6. Comando para arrancar
ENTRYPOINT ["dotnet", "API_CitasMedicas.dll"]
