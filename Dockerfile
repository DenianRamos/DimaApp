FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY Dima.Api/Dima.Api.csproj Dima.Api/
COPY Dima.Core/Dima.Core.csproj Dima.Core/
RUN dotnet restore Dima.Api/Dima.Api.csproj

COPY . .
RUN dotnet publish Dima.Api/Dima.Api.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "Dima.Api.dll"]
