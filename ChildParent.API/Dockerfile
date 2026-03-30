FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app

# ✅ ADD THIS LINE
ENV ASPNETCORE_URLS=http://+:8080

EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ChildParent.API/ChildParent.API.csproj", "ChildParent.API/"]
RUN dotnet restore "./ChildParent.API/ChildParent.API.csproj"
COPY . .
WORKDIR "/src/ChildParent.API"
RUN dotnet build "./ChildParent.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ChildParent.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChildParent.API.dll"]