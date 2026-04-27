FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiamos todo el contenido del repo
COPY . ./

# Restauramos apuntando específicamente al archivo de solución
RUN dotnet restore API_CitasMedicas.slnx

# Publicamos el proyecto de la API (ajustando la ruta a la subcarpeta)
RUN dotnet publish API_CitasMedicas/API_CitasMedicas.csproj -c Release -o out

# Imagen de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Asegúrate de que el nombre de la DLL sea este (puedes verificarlo en tu carpeta bin local si tienes duda)
ENTRYPOINT ["dotnet", "API_CitasMedicas.dll"]
