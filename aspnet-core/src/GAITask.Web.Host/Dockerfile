FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/GAITask.Web.Host/GAITask.Web.Host.csproj", "src/GAITask.Web.Host/"]
COPY ["src/GAITask.Web.Core/GAITask.Web.Core.csproj", "src/GAITask.Web.Core/"]
COPY ["src/GAITask.Application/GAITask.Application.csproj", "src/GAITask.Application/"]
COPY ["src/GAITask.Core/GAITask.Core.csproj", "src/GAITask.Core/"]
COPY ["src/GAITask.EntityFrameworkCore/GAITask.EntityFrameworkCore.csproj", "src/GAITask.EntityFrameworkCore/"]
WORKDIR "/src/src/GAITask.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/GAITask.Web.Host", "src/GAITask.Web.Host"]
COPY ["src/GAITask.Web.Core", "src/GAITask.Web.Core"]
COPY ["src/GAITask.Application", "src/GAITask.Application"]
COPY ["src/GAITask.Core", "src/GAITask.Core"]
COPY ["src/GAITask.EntityFrameworkCore", "src/GAITask.EntityFrameworkCore"]
WORKDIR "/src/src/GAITask.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "GAITask.Web.Host.dll"]
