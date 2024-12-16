
# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Establece el directorio de trabajo
WORKDIR /app

# Copia el archivo de proyecto (.csproj) y restaura las dependencias (usando el comando dotnet restore)
COPY api-dicsys/api-dicsys.csproj ./
RUN dotnet restore

# Copia todos los archivos del proyecto y construye la aplicación
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Etapa final para la ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Establece el directorio de trabajo
WORKDIR /app

# Expone el puerto 80 para que la aplicación sea accesible
EXPOSE 80

# Copia los archivos de la etapa de construcción
COPY --from=build /app/publish .

# Comando para ejecutar la aplicación
ENTRYPOINT ["dotnet", "api-dicsys.dll"]
