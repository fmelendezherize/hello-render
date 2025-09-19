# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar el archivo del proyecto y restaurar dependencias
COPY RenderLab1.csproj ./
RUN dotnet restore

# Copiar todo el código y publicar en modo Release
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copiar la publicación desde la etapa build
COPY --from=build /app/out ./

# Indicar que escuchamos en el puerto 8080
ENV ASPNETCORE_HTTP_PORTS=8080

# Exponer el puerto 8080
EXPOSE 8080

# Ejecutar la aplicación
ENTRYPOINT ["dotnet", "RenderLab1.dll"]
