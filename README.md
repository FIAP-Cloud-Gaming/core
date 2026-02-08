# FIAP Cloud Gaming - Core

Building blocks fundamentais para os microsservicos da FIAP Cloud Gaming. Este repositorio fornece dois pacotes NuGet:

## Pacotes

### FiapCloudGaming.SeedWork

Classes base e interfaces de Domain-Driven Design com zero dependencias de infraestrutura.

| Classe / Interface | Finalidade |
|-------------------|---------|
| `Entity` | Entidade base com igualdade por identidade |
| `EntityWithNotification` | Entidade com suporte a eventos de dominio |
| `ValueObject` | Value object base com igualdade estrutural |
| `IAggregateRoot` | Interface marcadora para aggregate roots |
| `IRepository<T>` | Interface generica de repositorio |
| `IUnitOfWork` | Padrao Unit of Work |
| `Result` / `Result<T>` | Tratamento de erros orientado a fluxo (Railway) |
| `Error` / `ErrorType` | Modelo de erro tipado com factory methods |
| `ValidationError` | Agregacao de multiplos erros de validacao |
| `PagedResponse<T>` | Resposta paginada generica |
| `INotificationContext` | Contexto de coleta de eventos de dominio |
| `MediatorExtensions` | Despacha eventos de dominio via Mediator |

```bash
dotnet add package FiapCloudGaming.SeedWork
```

### FiapCloudGaming.ServiceDefaults

Configuracao compartilhada de servicos para microsservicos ASP.NET Core.

| Funcionalidade | Descricao |
|---------|-------------|
| Serilog | Logging estruturado com saida em console, enrichers (Machine, Environment, Thread, Span) |
| OpenTelemetry | Tracing, metricas e logging com suporte a exportador OTLP |
| Health Checks | Endpoints `/health` e `/alive` |
| ActivityExtensions | Helpers de OpenTelemetry para tags de excecao e tags customizadas |

```bash
dotnet add package FiapCloudGaming.ServiceDefaults
```

**Uso:**

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddDefaultHealthChecks();

var app = builder.Build();

app.MapDefaultEndpoints();
```

## Configuracao

### Consumir pacotes localmente

Adicione a source do GitHub Packages com autenticacao:

```bash
dotnet nuget update source github-fcg \
  --username SEU_USUARIO_GITHUB \
  --password SEU_TOKEN_PAT \
  --store-password-in-clear-text \
  --configfile nuget.config
```

### nuget.config para projetos consumidores

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <clear />
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />
    <add key="github-fcg" value="https://nuget.pkg.github.com/FIAP-Cloud-Gaming/index.json" />
  </packageSources>
  <packageSourceMapping>
    <packageSource key="nuget.org">
      <package pattern="*" />
    </packageSource>
    <packageSource key="github-fcg">
      <package pattern="FiapCloudGaming.*" />
    </packageSource>
  </packageSourceMapping>
</configuration>
```

## Dependencias

- **SeedWork**: [FiapCloudGaming.Mediator](https://github.com/FIAP-Cloud-Gaming/Mediator)
- **ServiceDefaults**: OpenTelemetry, Serilog, ASP.NET Core

## Licenca

MIT
