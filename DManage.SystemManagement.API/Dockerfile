#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["DManage.SystemManagement.API/DManage.SystemManagement.API.csproj", "DManage.SystemManagement.API/"]
COPY ["DManage.SystemManagement.Infrastructure/DManage.SystemManagement.Infrastructure.csproj", "DManage.SystemManagement.Infrastructure/"]
COPY ["DManage.SystemManagement.Application/DManage.SystemManagement.Application.csproj", "DManage.SystemManagement.Application/"]
COPY ["DManage.SystemManagement.Domain/DManage.SystemManagement.Domain.csproj", "DManage.SystemManagement.Domain/"]
RUN dotnet restore "DManage.SystemManagement.API/DManage.SystemManagement.API.csproj"
COPY . .
WORKDIR "/src/DManage.SystemManagement.API"
RUN dotnet build "DManage.SystemManagement.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DManage.SystemManagement.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DManage.SystemManagement.API.dll"]
