# Dima

Projeto simples em .NET 8 para praticar Git, GitHub Flow, CI/CD com GitHub Actions e Docker.

## Como executar localmente

```powershell
dotnet restore Dima.sln
dotnet run --project .\Dima.Api\Dima.Api.csproj
```

Endpoints:

- `GET /health`
- `GET /v2/products`

## Testes

```powershell
dotnet test Dima.sln
```

## Docker

```powershell
docker build -t dima-api .
docker run --rm -p 8080:8080 dima-api
```
