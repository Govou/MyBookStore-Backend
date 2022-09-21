#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443



FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src

COPY ["./MyBookStore.API/MyBookStore.API.csproj", "MyBookStore.API/"]
COPY ["./MyBookStore.Application/MyBookStore.Application.csproj", "MyBookStore.Application/"]
COPY ["./MyBookStore.Core/MyBookStore.Core.csproj", "MyBookStore.Core/"]
COPY ["./MyBookStore.Domain/MyBookStore.Domain.csproj", "MyBookStore.Domain/"]
COPY ["./MyBookStore.Infrastructure/MyBookStore.Infrastructure.csproj", "MyBookStore.Infrastructure/"]
COPY ["./MyBookStore.Backend.sln", "."]
RUN dotnet restore 

COPY . .

WORKDIR "/src/MyBookStore.API"
RUN dotnet build "MyBookStore.API.csproj" -c Release -o /app/build

WORKDIR "/src/MyBookStore.Application"
RUN dotnet build "MyBookStore.Application.csproj" -c Release -o /app/build

WORKDIR "/src/MyBookStore.Core"
RUN dotnet build "MyBookStore.Core.csproj" -c Release -o /app/build

WORKDIR "/src/MyBookStore.Domain"
RUN dotnet build "MyBookStore.Domain.csproj" -c Release -o /app/build

WORKDIR "/src/MyBookStore.Infrastructure"
RUN dotnet build "MyBookStore.Infrastructure.csproj" -c Release -o /app/build

WORKDIR "/src/MyBookStore.API"
FROM build AS publish
 RUN dotnet publish "MyBookStore.API.csproj" -o /app/publish/

 FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "MyBookStore.API.dll"]