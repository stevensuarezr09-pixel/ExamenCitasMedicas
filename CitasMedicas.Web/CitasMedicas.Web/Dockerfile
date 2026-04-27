FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# 1. Copiamos TODO el contenido del repositorio (todas las carpetas)
COPY . .

# 2. Restauramos las dependencias buscando el archivo de la WEB
RUN dotnet restore $(find . -name "CitasMedicas.Web.csproj")

# 3. Publicamos el proyecto de la Web
# Al estar en la raíz, sí encontrará la carpeta de la API que necesita
RUN dotnet publish $(find . -name "CitasMedicas.Web.csproj") -c Release -o out

# 4. Imagen de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# 5. Punto de entrada
ENTRYPOINT ["dotnet", "CitasMedicas.Web.dll"]
