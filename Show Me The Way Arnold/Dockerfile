FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Show Me The Way Arnold/Show Me The Way Arnold.csproj", "Show Me The Way Arnold/"]
RUN dotnet restore "Show Me The Way Arnold/Show Me The Way Arnold.csproj"
COPY . .
WORKDIR "/src/Show Me The Way Arnold"
RUN dotnet build "Show Me The Way Arnold.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Show Me The Way Arnold.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Show Me The Way Arnold.dll"]
