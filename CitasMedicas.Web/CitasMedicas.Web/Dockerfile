FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 1. Copiamos TODO el repositorio a la carpeta /src
COPY . .

# 2. Forzamos la restauración del proyecto Web buscando el archivo donde sea que esté
RUN dotnet restore $(find . -name "CitasMedicas.Web.csproj")

# 3. Publicamos el proyecto Web. 
# Al estar en /src (la raíz), el compilador encontrará la carpeta API_CitasMedicas sin problemas.
RUN dotnet publish $(find . -name "CitasMedicas.Web.csproj") -c Release -o /app/publish

# 4. Imagen final de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "CitasMedicas.Web.dll"]
