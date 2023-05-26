FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/ProjectManager.Api/ProjectManager.Api.csproj", "src/ProjectManager.Api/"]
RUN dotnet restore "src/ProjectManager.Api/ProjectManager.Api.csproj"
COPY . .
WORKDIR "/src/src/ProjectManager.Api"
RUN dotnet build "ProjectManager.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjectManager.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjectManager.Api.dll"]
