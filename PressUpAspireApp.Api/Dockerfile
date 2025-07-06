FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project files for restore
COPY ["PressUpAspireApp.Api/PressUpAspireApp.Api.csproj", "PressUpAspireApp.Api/"]
COPY ["PressUpAspireApp.ServiceDefaults/PressUpAspireApp.ServiceDefaults.csproj", "PressUpAspireApp.ServiceDefaults/"]

RUN dotnet restore "PressUpAspireApp.Api/PressUpAspireApp.Api.csproj"

COPY . .
WORKDIR "/src/PressUpAspireApp.Api"

RUN dotnet build "./PressUpAspireApp.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release

RUN dotnet publish "./PressUpAspireApp.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "PressUpAspireApp.Api.dll"]
