FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["event-drivenProgramming/event-drivenProgramming.csproj", "event-drivenProgramming/"]
RUN dotnet restore "event-drivenProgramming/event-drivenProgramming.csproj"
COPY . .
WORKDIR "/src/event-drivenProgramming"
RUN dotnet build "event-drivenProgramming.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "event-drivenProgramming.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "event-drivenProgramming.dll"]
