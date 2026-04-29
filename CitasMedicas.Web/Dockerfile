FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiamos todo
COPY . .

# USAMOS EL NOMBRE DIRECTO PARA QUE NO SE CONFUNDA CON OTROS PROYECTOS
RUN dotnet publish "CitasMedicas.Web.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "CitasMedicas.Web.dll"]
