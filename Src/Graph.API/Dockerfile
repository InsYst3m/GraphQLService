#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Graph.API/Graph.API.csproj", "Graph.API/"]
COPY ["Graph.DataAccess/Graph.DataAccess.csproj", "Graph.DataAccess/"]
COPY ["Graph.Domain/Graph.Domain.csproj", "Graph.Domain/"]
RUN dotnet restore "Graph.API/Graph.API.csproj"
COPY . .
WORKDIR "/src/Graph.API"
RUN dotnet build "Graph.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Graph.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Graph.API.dll"]