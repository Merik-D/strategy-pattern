FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["strategy-pattern/strategy-pattern.csproj", "strategy-pattern/"]
RUN dotnet restore "strategy-pattern/strategy-pattern.csproj"
COPY . .
WORKDIR "/src/strategy-pattern"
RUN dotnet build "strategy-pattern.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "strategy-pattern.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY strategy-pattern/appsettings.json ./ 
ENTRYPOINT ["dotnet", "strategy-pattern.dll"]