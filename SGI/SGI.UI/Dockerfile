FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["SGI.Repositorios/SGI.Repositorios.csproj", "SGI.Repositorios/"]
COPY ["SGI.Aplicacion/SGI.Aplicacion.csproj", "SGI.Aplicacion/"]
COPY ["SGI.UI/SGI.UI.csproj", "SGI.UI/"]

RUN dotnet restore "SGI.UI/SGI.UI.csproj"

COPY . .

WORKDIR "/src/SGI.UI"
RUN dotnet publish "SGI.UI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000

ENTRYPOINT ["dotnet", "SGI.UI.dll"]