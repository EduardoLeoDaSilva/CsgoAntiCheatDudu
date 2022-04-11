FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 5078

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["CsgoAntiCheatDudu.csproj", "./"]
RUN dotnet restore "CsgoAntiCheatDudu.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "CsgoAntiCheatDudu.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CsgoAntiCheatDudu.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet CsgoAntiCheatDudu.dll
