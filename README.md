# proxiFiltros

This project provides an ASP.NET Core Web API that acts as a REST gateway for the `EvaluarPwcPrecalificacion` SOAP service. The solution follows a simple Domain-Driven Design (DDD) approach separating Domain, Application, Infrastructure and Web layers.

## Structure

- **Domain** – Entities representing the request payload.
- **Application** – Service interfaces and implementations.
- **Infrastructure** – SOAP client that builds and sends the envelope.
- **WebApi** – REST API controllers and application bootstrap.

## Running

A .NET 6 SDK or later is required.

```bash
dotnet run --project src/WebApi/WebApi.csproj
```

The API exposes a single endpoint:

- `POST /Precalificacion/evaluar` – accepts a JSON body matching `PrecalificacionRequest` and returns the raw SOAP response as `soapResponse`.

This service forwards the provided data to the SOAP endpoint configured in `Program.cs`.

Create a `.env` file in the project root to configure the SOAP URL and other settings:

```env
WSExperian_Service=http://172.21.30.10:9000/ws_experian/service.asmx
```
