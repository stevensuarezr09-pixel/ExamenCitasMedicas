FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# 1. Copiamos todo el contenido del repositorio
COPY . .

# 2. Restauramos las dependencias
RUN dotnet restore

# 3. Publicamos el proyecto específico de la Web
# El comando find ayuda a que Render no se pierda con las carpetas
RUN dotnet publish $(find . -name "CitasMedicas.Web.csproj") -c Release -o out

# 4. Imagen de ejecución final
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# 5. ¡OJO AQUÍ!: Asegúrate que el nombre de la DLL sea el de tu proyecto Web
ENTRYPOINT ["dotnet", "CitasMedicas.Web.dll"]
