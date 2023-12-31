#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MyApp.Api/MyApp.Api.csproj", "MyApp.Api/"]
COPY ["MyApp.Infrastructure/MyApp.Data.csproj", "MyApp.Infrastructure/"]
COPY ["MyApp.Domain/MyApp.Domain.csproj", "MyApp.Domain/"]
COPY ["MyApp.CrossCutting/MyApp.CrossCutting.csproj", "MyApp.CrossCutting/"]
COPY ["MyApp.Services/MyApp.Services.csproj", "MyApp.Services/"]
COPY ["MyApp.Application/MyApp.Application.csproj", "MyApp.Application/"]
RUN dotnet restore "MyApp.Api/MyApp.Api.csproj"
COPY . .
WORKDIR "/src/MyApp.Api"
RUN dotnet build "MyApp.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyApp.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyApp.Api.dll"]