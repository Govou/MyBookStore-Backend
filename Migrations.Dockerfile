FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src
COPY ["./MyBookStore.API/MyBookStore.API.csproj", "./"]
COPY ["./MyBookStore.Application/MyBookStore.Application.csproj", "./MyBookStore.Application"]
COPY ["./MyBookStore.Core/MyBookStore.Core.csproj", "./MyBookStore.Core"]
COPY ["./MyBookStore.Domain/MyBookStore.Domain.csproj", "./MyBookStore.Domain"]
COPY ["./MyBookStore.Infrastructure/MyBookStore.Infrastructure.csproj", "./Infrastructure.csproj"]

COPY Setup.sh Setup.sh

RUN dotnet tool install --global dotnet-ef

RUN dotnet restore "./MyBookStore.API.csproj"
COPY . .
COPY "./MyBookStore.Application", "./MyBookStore.Application"
COPY "./MyBookStore.Core", "./MyBookStore.Core"
COPY "./MyBookStore.Domain", "./MyBookStore.Domain"
COPY "./MyBookStore.Infrastructure", "./MyBookStore.Infrastructure"
WORKDIR "/src/."



RUN /root/.dotnet/tools/dotnet-ef migrations add InitialMigrations -v

RUN chmod +x ./Setup.sh
CMD /bin/bash ./Setup.sh