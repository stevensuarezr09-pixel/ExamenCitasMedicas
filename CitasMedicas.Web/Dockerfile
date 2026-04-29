FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# Nos paramos en la raíz del contenedor
WORKDIR /src

# Copiamos TODO lo que hay en la carpeta donde está el Dockerfile
COPY . .

# Comando de publicación usando el nombre exacto que veo en tus capturas
RUN dotnet publish "CitasMedicas.Web.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

# Asegúrate de que el nombre sea exacto
ENTRYPOINT ["dotnet", "CitasMedicas.Web.dll"]
