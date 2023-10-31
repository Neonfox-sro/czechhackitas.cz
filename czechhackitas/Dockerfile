FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["czechhackitas/czechhackitas.csproj", "czechhackitas/"]
RUN dotnet restore "czechhackitas/czechhackitas.csproj"
COPY . .
WORKDIR "/src/czechhackitas"
RUN dotnet build "czechhackitas.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "czechhackitas.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "czechhackitas.dll"]
