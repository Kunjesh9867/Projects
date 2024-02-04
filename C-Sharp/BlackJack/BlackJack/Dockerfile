FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BlackJack/BlackJack.csproj", "BlackJack/"]
RUN dotnet restore "BlackJack/BlackJack.csproj"
COPY . .
WORKDIR "/src/BlackJack"
RUN dotnet build "BlackJack.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlackJack.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlackJack.dll"]
