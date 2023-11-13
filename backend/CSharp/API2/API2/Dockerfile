FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5110
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY API2.csproj .
RUN dotnet restore "API2.csproj"
COPY . .
RUN dotnet build "API2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API2.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API2.dll"]
