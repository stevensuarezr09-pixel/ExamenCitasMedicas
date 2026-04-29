FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 1. Copiamos TODO el repositorio para estar seguros
COPY . .

# 2. Forzamos la búsqueda del proyecto en cualquier carpeta
# Esto evita el error de "Project file does not exist"
RUN dotnet publish $(find . -name "CitasMedicas.Web.csproj") -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

# El nombre de la DLL (basado en tus capturas anteriores)
ENTRYPOINT ["dotnet", "CitasMedicas.Web.dll"]
