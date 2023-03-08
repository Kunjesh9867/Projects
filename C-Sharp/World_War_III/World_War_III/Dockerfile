FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["World_War_III/World_War_III.csproj", "World_War_III/"]
RUN dotnet restore "World_War_III/World_War_III.csproj"
COPY . .
WORKDIR "/src/World_War_III"
RUN dotnet build "World_War_III.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "World_War_III.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "World_War_III.dll"]
