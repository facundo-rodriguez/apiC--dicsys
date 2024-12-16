# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Establece el directorio de trabajo
WORKDIR /app

# Copia el archivo de proyecto (.csproj) desde la raíz y restaura las dependencias
COPY api-dicsys.csproj ./  
RUN dotnet restore api-dicsys.csproj   

# Copia todos los archivos del proyecto desde la raíz (ya no hace falta 'api-dicsys/.')
COPY . ./                   

# Publica la aplicación
RUN dotnet publish api-dicsys.csproj -c Release -o /app/publish

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
