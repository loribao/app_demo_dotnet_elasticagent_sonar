FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS buildbase
RUN dotnet tool install --global dotnet-sonarscanner

FROM buildbase AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/AppDemo.Server/AppDemo.Server.csproj", "src/AppDemo.Server/"]
RUN dotnet restore "src/AppDemo.Server/AppDemo.Server.csproj"
COPY . .
WORKDIR "/src/src/AppDemo.Server"
RUN dotnet build "AppDemo.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AppDemo.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false



FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ["/var/ossec/bin/wazuh-control", "start", "&&", "dotnet", "AppDemo.Server.dll"] 