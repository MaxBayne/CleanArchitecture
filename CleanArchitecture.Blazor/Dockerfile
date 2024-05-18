#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["../Directory.Packages.props", "."]
COPY ["../Directory.Build.props", "."]
COPY ["../CleanArchitecture.Blazor/CleanArchitecture.Blazor.csproj", "CleanArchitecture.Blazor/"]
COPY ["../CleanArchitecture.Application/CleanArchitecture.Application.csproj", "CleanArchitecture.Application/"]
COPY ["../CleanArchitecture.Domain/CleanArchitecture.Domain.csproj", "CleanArchitecture.Domain/"]
COPY ["../CleanArchitecture.Common/CleanArchitecture.Common.csproj", "CleanArchitecture.Common/"]
RUN dotnet restore "./CleanArchitecture.Blazor/./CleanArchitecture.Blazor.csproj"
COPY . .
WORKDIR "/src/CleanArchitecture.Blazor"
RUN dotnet build "./CleanArchitecture.Blazor.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CleanArchitecture.Blazor.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CleanArchitecture.Blazor.dll"]