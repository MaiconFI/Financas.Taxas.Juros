#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Financas.Taxas.Juros.Api/Financas.Taxas.Juros.Api.csproj", "src/Financas.Taxas.Juros.Api/"]
COPY ["src/Financas.Taxas.Juros.Queries/Financas.Taxas.Juros.Queries.csproj", "src/Financas.Taxas.Juros.Queries/"]
COPY ["src/Financas.Taxas.Juros.Domain/Financas.Taxas.Juros.Domain.csproj", "src/Financas.Taxas.Juros.Domain/"]
COPY ["src/Financas.Taxas.Juros.Dtos/Financas.Taxas.Juros.Dtos.csproj", "src/Financas.Taxas.Juros.Dtos/"]
COPY ["src/Financas.Taxas.Juros.Data/Financas.Taxas.Juros.Data.csproj", "src/Financas.Taxas.Juros.Data/"]
COPY ["src/Financas.Taxas.Juros.Domain.Repositories/Financas.Taxas.Juros.Domain.Repositories.csproj", "src/Financas.Taxas.Juros.Domain.Repositories/"]
RUN dotnet restore "src/Financas.Taxas.Juros.Api/Financas.Taxas.Juros.Api.csproj"
COPY . .
WORKDIR "/src/src/Financas.Taxas.Juros.Api"
RUN dotnet build "Financas.Taxas.Juros.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Financas.Taxas.Juros.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Financas.Taxas.Juros.Api.dll"]
