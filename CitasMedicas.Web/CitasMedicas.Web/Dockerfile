FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# 1. Copiamos TODO el contenido del repositorio (todas las carpetas)
# Al dejar el Root Directory vacío en Render, este punto "." es la raíz del repo
COPY . .

# 2. Restauramos las dependencias
RUN dotnet restore "CitasMedicas.Web/CitasMedicas.Web/CitasMedicas.Web.csproj"

# 3. Publicamos el proyecto de la Web
# Ahora sí encontrará la carpeta de la API porque estamos compilando desde la raíz
RUN dotnet publish "CitasMedicas.Web/CitasMedicas.Web/CitasMedicas.Web.csproj" -c Release -o out

# 4. Imagen de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# 5. Punto de entrada
ENTRYPOINT ["dotnet", "CitasMedicas.Web.dll"]
