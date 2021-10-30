FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Arnold Web API/Arnold Web API.csproj", "Arnold Web API/"]
RUN dotnet restore "Arnold Web API/Arnold Web API.csproj"
COPY . .
WORKDIR "/src/Arnold Web API"
RUN dotnet build "Arnold Web API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Arnold Web API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Arnold Web API.dll"]
