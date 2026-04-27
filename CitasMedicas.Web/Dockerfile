FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiamos absolutamente todo el contenido
COPY . .

# Buscamos el .csproj en todas las subcarpetas y lo publicamos
RUN dotnet publish $(find . -name "*.csproj") -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

# El nombre de la DLL debe ser este (basado en tu imagen image_02eebf)
ENTRYPOINT ["dotnet", "CitasMedicas.Web.dll"]
