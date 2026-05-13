# IQeSign.TicketBai

[![NuGet](https://img.shields.io/nuget/v/IQeSign.TicketBai.svg)](https://www.nuget.org/packages/IQeSign.TicketBai)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![.NET](https://img.shields.io/badge/.NET-net8.0%20%7C%20netstandard2.1-purple)](https://dotnet.microsoft.com)

Cliente .NET para la **API IQ eSign TicketBAI** de [InnoQubit Software](https://www.innoqubit.com). Permite integrar desde cualquier aplicación .NET la presentación de facturas electrónicas a las haciendas forales del País Vasco (**Álava, Gipuzkoa y Bizkaia**), gestionando certificados digitales, firma de peticiones y encadenamiento automático.

---

## Sobre InnoQubit

[**InnoQubit Business Software**](https://www.innoqubit.com) es una empresa tecnológica con sede en Castellón (España), especializada en la **digitalización y automatización de procesos empresariales** para sistemas ERP.

Su producto insignia **IQ eSign** agrupa soluciones de facturación electrónica y firma digital que se integran con cualquier ERP (Microsoft Dynamics 365 Business Central, Navision y software a medida):

| Solución | Descripción |
|---|---|
| **IQ eSign VeriFactu** | Presentación de facturas al sistema VeriFactu de la AEAT |
| **IQ eSign TicketBAI** | Facturación electrónica para el País Vasco |
| **IQ eSign Facturae** | Generación y envío de facturas en formato Facturae |
| **IQ eSign ePDF** | Generación de PDFs firmados digitalmente |

---

## ¿Qué es TicketBAI?

**TicketBAI** es el sistema de facturación electrónica obligatorio en el País Vasco, regulado por las haciendas forales de Álava, Gipuzkoa y Bizkaia. Garantiza la integridad de cada factura mediante encadenamiento de firmas digitales y su presentación en tiempo real a la hacienda foral correspondiente.

Este paquete encapsula toda la complejidad de la integración:

- Autenticación JWT automática con refresco de token
- Firma de peticiones con certificado digital (.pfx) almacenado en IQ Portal
- Encadenamiento automático de facturas (gestión de `HuellaTbai`)
- Soporte para facturas emitidas y recibidas
- Soporte para correcciones (**Zuzendu**) en Álava y Gipuzkoa
- Gestión de facturas simplificadas y rectificativas
- Reintentos de envío para documentos con fallos transitorios

---

## Instalación

```bash
dotnet add package IQeSign.TicketBai
```

Para obtener una cuenta y el `CredentialGuid` necesarios para usar este paquete, contacta con el equipo comercial de InnoQubit en [comercial@innoqubit.com](mailto:comercial@innoqubit.com).

---

## Inicio rápido

### 1. Registro en el contenedor DI

```csharp
// Program.cs
builder.Services.AddIQeSignTicketBai(options =>
{
    options.CredentialGuid = builder.Configuration["IQeSignTicketBai:CredentialGuid"]!;
    options.Environment = IQeSignEnvironment.Production; // o Staging para pruebas
    options.TimeoutSeconds = 30;
});
```

O bien usando una sección de `appsettings.json`:

```json
{
  "IQeSignTicketBai": {
    "CredentialGuid": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx",
    "Environment": "Production"
  }
}
```

```csharp
builder.Services.AddIQeSignTicketBai(
    builder.Configuration.GetSection(IQeSignOptions.SectionName));
```

### 2. Enviar una factura emitida

```csharp
public class FacturacionService(ITicketBaiService ticketBai)
{
    public async Task<string> EnviarFacturaAsync(CancellationToken ct = default)
    {
        var response = await ticketBai.AddDocumentAsync(new AddDocumentRequest
        {
            CertificateId = "id-del-certificado-en-iqportal",
            CertificatePass = "contraseña-del-pfx",
            File = new TicketBaiDocumentFile
            {
                Issuer = new TicketBaiIssuerInfo
                {
                    Name = "Mi Empresa S.L.",
                    CifNif = "B12345678"
                },
                Serial = "FAC",
                Number = "2024-001",
                Date = "2024-01-15",
                Name = "Cliente S.A.",
                Nif = "A98765432",
                TotalInvoice = 1210.00m,
                Administration = Administration.Gipuzkoa,
                Lines =
                [
                    new InvoiceLine
                    {
                        Description = "Servicios de consultoría",
                        Quantity = 1,
                        UnitAmount = 1000.00m,
                        Vat = 21m,
                        VatSubject = true,
                        TaxKey = TaxKey.RegimenGeneral
                    }
                ]
            },
            Metadata = new DocumentMetadata { Platform = "MiApp" }
        }, ct);

        if (!response.IsSuccess)
            throw new Exception($"Error TicketBAI [{response.ErrorCode}]: {response.ErrorMessage}");

        return response.Result!.Id!;
    }
}
```

### 3. Registrar una factura recibida

```csharp
public class FacturasRecibidasService(ITicketBaiReceivedService received)
{
    public async Task<string> RegistrarAsync(CancellationToken ct = default)
    {
        var response = await received.AddReceivedAsync(new AddReceivedRequest
        {
            CertificateId = "id-del-certificado",
            CertificatePass = "contraseña",
            File = new ReceivedDocumentFile
            {
                Issuer = new ReceivedIssuerInfo
                {
                    Name = "Proveedor S.L.",
                    CifNif = "B87654321"
                },
                Serial = "PRV",
                Number = "2024-100",
                ReceivedDate = "2024-01-20",
                InvoiceDate = "2024-01-18",
                InvoiceType = ReceivedInvoiceType.FacturaConDestinatario,
                TotalInvoice = 605.00m
            }
        }, ct);

        if (!response.IsSuccess)
            throw new Exception($"[{response.ErrorCode}] {response.ErrorMessage}");

        return response.Result!.Id!;
    }
}
```

### 4. Gestión de certificados

```csharp
public class CertificadoService(ICertificateService certs)
{
    public async Task<string> SubirCertificadoAsync(byte[] pfxBytes, string nombre)
    {
        var resp = await certs.AddAsync(new AddCertificateRequest
        {
            Name = nombre,
            File = Convert.ToBase64String(pfxBytes)
        });
        return resp.Result!.Id;
    }
}
```

---

## Servicios disponibles

### `ITicketBaiService` — Facturas emitidas

| Método | Endpoint | Descripción |
|---|---|---|
| `GetUsageAsync()` | `GET /api/v2/Ticketbai/Usage` | Consulta el consumo del plan contratado |
| `AddDocumentAsync(request)` | `POST /api/v2/TicketBai/Document` | Envía una factura emitida a la hacienda foral |
| `GetDocumentByIdAsync(id)` | `GET /api/v2/TicketBai/Document/{id}` | Consulta el estado y datos de un documento |
| `DownloadDocumentAsync(id)` | `GET /api/v2/TicketBai/Document/{id}/Download` | Descarga el ZIP con el XML firmado (Base64) |
| `CancelDocumentAsync(id)` | `PUT /api/v2/TicketBai/Document/{id}/Cancel` | Cancela un documento en la hacienda foral |
| `RetryDocumentAsync(id)` | `PUT /api/v2/TicketBai/Document/{id}/Retry` | Reintenta un envío fallido (Processed=false) |
| `ListDocumentsAsync(filtros?)` | `GET /api/v2/TicketBai/Document/List` | Lista documentos con filtro de fechas opcional |
| `AddZuzenduAsync(id, request)` | `POST /api/v2/TicketBai/Document/{id}/Zuzendu` | Envía una corrección Zuzendu (Álava/Gipuzkoa) |
| `CancelZuzenduAsync(id)` | `PUT /api/v2/TicketBai/Document/{id}/Zuzendu/Cancel` | Cancela un Zuzendu |

### `ITicketBaiReceivedService` — Facturas recibidas

| Método | Endpoint | Descripción |
|---|---|---|
| `AddReceivedAsync(request)` | `POST /api/v2/TicketBai/Received` | Registra una factura recibida |
| `CancelReceivedAsync(id, request)` | `PUT /api/v2/TicketBai/Received/{id}/Cancel` | Cancela una factura recibida |
| `CheckReceivedAsync(id, request)` | `PUT /api/v2/TicketBai/Received/{id}/Check` | Consulta el estado en la hacienda foral |
| `UpdateReceivedAsync(id, request)` | `PUT /api/v2/TicketBai/Received/{id}` | Actualiza una factura recibida |
| `ListReceivedAsync(filtros?)` | `GET /api/v2/TicketBai/Received/List` | Lista facturas recibidas con filtro de fechas |

### `ICertificateService` — Certificados digitales

| Método | Endpoint | Descripción |
|---|---|---|
| `AddAsync(request)` | `POST /api/v2/Certificate` | Sube un certificado .pfx en Base64 |
| `GetByIdAsync(id)` | `GET /api/v2/Certificate/{id}` | Consulta un certificado por ID |
| `DownloadAsync(id)` | `GET /api/v2/Certificate/{id}/Download` | Descarga el .pfx en Base64 |
| `ListAsync()` | `GET /api/v2/Certificate/List` | Lista todos los certificados |
| `DeleteAsync(id)` | `DELETE /api/v2/Certificate/{id}` | Elimina un certificado |

---

## Listas de referencia TicketBAI

```csharp
// Administración hacienda foral
Administration.Alava       // "Álava"
Administration.Gipuzkoa    // "Gipuzkoa"
Administration.Bizkaia     // "Bizkaia" (solo facturas emitidas, no Zuzendu)

// Clave fiscal / régimen (L9)
TaxKey.RegimenGeneral      // "01"
TaxKey.Exportacion         // "02"

// Causa de exención (L10)
VatCause.Articulo20        // "E1"
VatCause.NoSujetoArticulo7 // "OT"

// Tipo de operación emitida (L11)
OperationTypeEmitted.SinInversion  // "S1"
OperationTypeEmitted.ConInversion  // "S2"

// Tipo de factura recibida (L18)
ReceivedInvoiceType.FacturaConDestinatario     // "F1"
ReceivedInvoiceType.FacturaSinDestinatario     // "F2"

// Código de rectificación (L7)
RectificationCode.R1  // "R1" — Error fundado en derecho
RectificationCode.R5  // "R5" — Facturas simplificadas

// Tipo de compra (L19)
PurchaseType.ComprasBienes   // "C"
PurchaseType.Gastos          // "G"
PurchaseType.BienesInversion // "I"

// Inversión del sujeto pasivo (L20)
ReverseCharge.Si  // "S"
ReverseCharge.No  // "N"
```

---

## Documentos con envío fallido (Processed = false)

Si el envío a la hacienda foral falla por un error transitorio, la API devuelve el `Id` del documento pero con `Processed = false`. Usa `RetryDocumentAsync` para reintentarlo:

```csharp
var doc = await ticketBai.GetDocumentByIdAsync(id, ct);
if (!doc.Result!.Processed)
{
    var retry = await ticketBai.RetryDocumentAsync(id, ct);
    if (!retry.IsSuccess)
        Console.WriteLine($"Reintento fallido: {retry.ErrorMessage}");
}
```

Si existe un documento pendiente con `Processed = false`, la API devuelve el aviso `"00001"` al intentar enviar uno nuevo. Resuelve primero el documento pendiente con `RetryDocumentAsync`.

---

## Control de errores

```csharp
var response = await ticketBai.AddDocumentAsync(request, ct);

if (!response.IsSuccess)
{
    // ErrorCode "0"  → éxito
    // ErrorCode "8"  → validación incorrecta (datos, ID no encontrado, plataforma rechaza)
    // ErrorCode "9"  → error no controlado (ver ErrorMessage)
    // Otros valores  → error de negocio controlado (ver ErrorMessage)
    Console.WriteLine($"[{response.ErrorCode}] {response.ErrorMessage}");
}

// Avisos de la plataforma (no impiden el registro)
foreach (var w in response.Result?.Warning ?? [])
    Console.WriteLine($"Aviso [{w.Code}]: {w.Message} / {w.Azalpena}");
```

Las excepciones se lanzan únicamente ante fallos de comunicación:

| Excepción | Cuándo se lanza |
|---|---|
| `IQeSignAuthException` | El `CredentialGuid` es inválido o la cuenta está inactiva |
| `IQeSignApiException` | La API devuelve un código HTTP 4xx/5xx inesperado |

---

## Entornos

| Entorno | URL | Uso |
|---|---|---|
| `IQeSignEnvironment.Production` | `https://iqesignapi.azurewebsites.net` | Producción real |
| `IQeSignEnvironment.Staging` | `https://iqesignapistaging.azurewebsites.net` | Pruebas e integración |

---

## Requisitos

- .NET 8.0 o .NET Standard 2.1 (compatible con .NET 6+, .NET 7+)
- Cuenta activa en [IQ Portal](https://www.innoqubit.com) con la solución IQ eSign TicketBAI contratada
- Certificado digital .pfx válido para firma de facturas (FNMT, ACA, etc.)

---

## Documentación adicional

- [Documentación técnica de la API IQ eSign TicketBAI (PDF)](https://www.innoqubit.com/wp-content/uploads/esign-ticketbai-memoria-tecnica.pdf)
- [IQ Portal — gestión de credenciales y certificados](https://www.innoqubit.com)
- [Swagger de la API (producción)](https://iqesignapi.azurewebsites.net/swagger/ui/index)

---

## Licencia

MIT © [InnoQubit Software](https://www.innoqubit.com)
