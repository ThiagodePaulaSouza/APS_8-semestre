FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["api1/api1.csproj", "api1/"]
RUN dotnet restore "api1/api1.csproj"
COPY . .
WORKDIR "/src/api1"
RUN dotnet build "api1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "api1.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api1.dll"]
