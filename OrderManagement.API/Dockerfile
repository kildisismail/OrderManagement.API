 FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
 WORKDIR /app
 EXPOSE 5001
 FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
 WORKDIR /src
 COPY ["OrderManagement.API.csproj", ""]
 RUN dotnet restore "./OrderManagement.API.csproj"
 COPY . .
 WORKDIR "/src/."
 RUN dotnet build "OrderManagement.API.csproj" -c Release -o /app/build
 FROM build AS publish
 RUN dotnet publish "OrderManagement.API.csproj" -c Release -o /app/publish
 FROM base AS final
 WORKDIR /app
 COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderManagement.API.dll"]