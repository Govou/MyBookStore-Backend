FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src
COPY ["MyBookStore.API.csproj", "./"]
COPY Setup.sh Setup.sh

RUN dotnet tool install --global dotnet-ef

RUN dotnet restore "./MyBookStore.API.csproj"
COPY . .
WORKDIR "/src/."

WORKDIR /src
COPY ["MyBookStore.Core.csproj", "./"]
COPY Setup.sh Setup.sh

RUN dotnet tool install --global dotnet-ef

RUN dotnet restore "./MyBookStore.Core.csproj"
COPY . .
WORKDIR "/src/."

WORKDIR /src
COPY ["MyBookStore.Domain.csproj", "./"]
COPY Setup.sh Setup.sh

RUN dotnet tool install --global dotnet-ef

RUN dotnet restore "./MyBookStore.Domain.csproj"
COPY . .
WORKDIR "/src/."

WORKDIR /src
COPY ["MyBookStore.Infrastructure.csproj", "./"]
COPY Setup.sh Setup.sh

RUN dotnet tool install --global dotnet-ef

RUN dotnet restore "./MyBookStore.Infrastructure.csproj"
COPY . .
WORKDIR "/src/."

WORKDIR /src
COPY ["MyBookStore.Application.csproj", "./"]
COPY Setup.sh Setup.sh

RUN dotnet tool install --global dotnet-ef

RUN dotnet restore "./MyBookStore.Application.csproj"
COPY . .
WORKDIR "/src/."

RUN /root/.dotnet/tools/dotnet-ef migrations add InitialMigrations -v

RUN chmod +x ./Setup.sh
CMD /bin/bash ./Setup.sh