#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BuscarReciclaveis/BuscarReciclaveis.csproj", "BuscarReciclaveis/"]
RUN dotnet restore "BuscarReciclaveis/BuscarReciclaveis.csproj"
COPY . .
WORKDIR "/src/BuscarReciclaveis"
RUN dotnet build "BuscarReciclaveis.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BuscarReciclaveis.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BuscarReciclaveis.dll"]