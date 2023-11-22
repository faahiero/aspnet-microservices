FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WebApps/ShoppingWebApp/ShoppingWebApp.csproj", "WebApps/ShoppingWebApp/"]
RUN dotnet restore "WebApps/ShoppingWebApp/ShoppingWebApp.csproj"
COPY . .
WORKDIR "/src/WebApps/ShoppingWebApp"
RUN dotnet build "ShoppingWebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShoppingWebApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT=Development
ENTRYPOINT ["dotnet", "ShoppingWebApp.dll"]
