FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /home/app

COPY ["./MyBookStore.API/MyBookStore.API.csproj", "MyBookStore.API/"]
COPY ["./MyBookStore.Application/MyBookStore.Application.csproj", "./MyBookStore.Application/"]
COPY ["./MyBookStore.Core/MyBookStore.Core.csproj", "./MyBookStore.Core/"]
COPY ["./MyBookStore.Domain/MyBookStore.Domain.csproj", "MyBookStore.Domain/"]
COPY ["./MyBookStore.Infrastructure/MyBookStore.Infrastructure.csproj", "MyBookStore.Infrastructure/"]
COPY ["./MyBookStore.Domain.Tests/MyBookStore.Domain.Tests.csproj", "MyBookStore.Tests/"]
COPY ["./MyBookStore.Application.Tests/MyBookStore.Application.Tests.csproj", "MyBookStore.Tests/"]
COPY ["./MyBookStore.Backend.sln", "."]
# COPY ["./MyBookStore.Infrastructure/MyBookStore.Infrastructure.csproj", "MyBookStore.Infrastructure/"]
RUN dotnet restore 

COPY . .

# WORKDIR "/src/WebApplication2"
#RUN dotnet build "WebApplication2.csproj" -c Release -o /app/build

# FROM build AS publish
 RUN dotnet publish "./MyBookStore.API/MyBookStore.API.csproj" -o /publish/

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .

WORKDIR /publish

ENTRYPOINT ["dotnet", "MyBookStore.API"]