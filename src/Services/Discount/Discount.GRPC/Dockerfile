FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Discount/Discount.GRPC/Discount.GRPC.csproj", "Services/Discount/Discount.GRPC/"]
RUN dotnet restore "Services/Discount/Discount.GRPC/Discount.GRPC.csproj"
COPY . .
WORKDIR "/src/Services/Discount/Discount.GRPC"
RUN dotnet build "Discount.GRPC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Discount.GRPC.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT=Development
ENTRYPOINT ["dotnet", "Discount.GRPC.dll"]
