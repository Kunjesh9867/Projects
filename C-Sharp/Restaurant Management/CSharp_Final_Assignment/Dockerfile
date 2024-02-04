FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CSharp_Final_Assignment/CSharp_Final_Assignment.csproj", "CSharp_Final_Assignment/"]
RUN dotnet restore "CSharp_Final_Assignment/CSharp_Final_Assignment.csproj"
COPY . .
WORKDIR "/src/CSharp_Final_Assignment"
RUN dotnet build "CSharp_Final_Assignment.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CSharp_Final_Assignment.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CSharp_Final_Assignment.dll"]
