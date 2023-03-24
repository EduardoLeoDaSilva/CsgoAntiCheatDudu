FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["WorkerAntixiter/WorkerAntixiter.csproj", "./"]
COPY ["/Common/Common.csproj", "/Common/"]
RUN dotnet restore "WorkerAntixiter.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Common/Common.csproj" -c Release -o /app/build/
RUN dotnet build "WorkerAntixiter.csproj" -c Release -o /app/build/


FROM build AS publish
RUN dotnet publish "WorkerAntixiter.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet WorkerAntixiter.dll

