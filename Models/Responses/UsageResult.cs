namespace IQeSign.TicketBai.Models.Responses;

/// <summary>
/// Documentos TicketBAI procesados por mes y año.
/// </summary>
public sealed class DocumentsPerMonthItem
{
    /// <summary>Año.</summary>
    public int Year { get; set; }

    /// <summary>Mes (1-12).</summary>
    public int Month { get; set; }

    /// <summary>Número de documentos procesados en ese mes y año.</summary>
    public int Documents { get; set; }
}

/// <summary>
/// Datos de uso de la solución IQ eSign TicketBAI.
/// </summary>
public sealed class TicketBaiUsageResult
{
    /// <summary>Número de certificados almacenados en IQ Portal.</summary>
    public int Certificates { get; set; }

    /// <summary>Número total de documentos procesados.</summary>
    public int Documents { get; set; }

    /// <summary>Desglose de documentos procesados por mes y año.</summary>
    public List<DocumentsPerMonthItem> DocumentsPerMonth { get; set; } = new();
}

/// <summary>Respuesta del endpoint GET Ticketbai/Usage.</summary>
public sealed class GetUsageResponse : ApiResponse<TicketBaiUsageResult> { }
