FROM nginx AS base
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WebApp.UI/WebApp.UI.csproj", "WebApp.UI/"]
COPY ["WebApp.Domain/WebApp.Domain.csproj", "WebApp.Domain/"]
RUN dotnet restore "WebApp.UI/WebApp.UI.csproj"
COPY . .
WORKDIR "/src/WebApp.UI"
RUN dotnet build "WebApp.UI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "WebApp.UI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY ["WebApp.UI/nginx.conf", "/etc/nginx/nginx.conf"]