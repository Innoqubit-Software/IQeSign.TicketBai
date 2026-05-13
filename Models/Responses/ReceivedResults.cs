namespace IQeSign.TicketBai.Models.Responses;

/// <summary>
/// Resultado de enviar una factura recibida TicketBAI.
/// </summary>
public sealed class SubmitReceivedResult
{
    /// <summary>Identificador de la factura recibida en IQ Portal.</summary>
    public string Id { get; set; } = string.Empty;
}

/// <summary>
/// Resultado de comprobar el estado de una factura recibida TicketBAI.
/// </summary>
public sealed class CheckReceivedResult
{
    /// <summary>Fecha de presentación del documento ante la hacienda foral.</summary>
    public string DatePresentation { get; set; } = string.Empty;

    /// <summary>Fecha de la última modificación del documento.</summary>
    public string DateLastModification { get; set; } = string.Empty;

    /// <summary>NIF del usuario que realizó la última modificación.</summary>
    public string NifLastModification { get; set; } = string.Empty;

    /// <summary>Tipo de presentación.</summary>
    public string TypePresentation { get; set; } = string.Empty;

    /// <summary>Estado del documento en la plataforma.</summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>Fecha de cancelación, si procede.</summary>
    public string DateCancelled { get; set; } = string.Empty;

    /// <summary>Descripción del error, si la operación resultó en error.</summary>
    public string ErrorDescription { get; set; } = string.Empty;
}

/// <summary>
/// Resumen de una factura recibida TicketBAI en el listado.
/// </summary>
public sealed class ReceivedSummary
{
    /// <summary>Identificador de la factura recibida en IQ Portal.</summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>Serie de la factura recibida.</summary>
    public string Serial { get; set; } = string.Empty;

    /// <summary>Número de la factura recibida.</summary>
    public string Number { get; set; } = string.Empty;

    /// <summary>Nombre del emisor de la factura recibida.</summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>Estado del documento.</summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>Fecha de recepción (contabilización).</summary>
    public string PostingDate { get; set; } = string.Empty;

    /// <summary>Fecha de la factura.</summary>
    public string InvoiceDate { get; set; } = string.Empty;
}

/// <summary>Respuesta del endpoint POST TicketBai/Received.</summary>
public sealed class AddReceivedResponse : ApiResponse<SubmitReceivedResult> { }

/// <summary>Respuesta del endpoint PUT TicketBai/Received/{id}.</summary>
public sealed class UpdateReceivedResponse : ApiResponse<SubmitReceivedResult> { }

/// <summary>Respuesta del endpoint PUT TicketBai/Received/{id}/Cancel.</summary>
public sealed class CancelReceivedResponse : ApiResponse { }

/// <summary>Respuesta del endpoint PUT TicketBai/Received/{id}/Check.</summary>
public sealed class CheckReceivedResponse : ApiResponse<CheckReceivedResult> { }

/// <summary>Respuesta del endpoint GET TicketBai/Received/List.</summary>
public sealed class ListReceivedResponse : ApiResponse<List<ReceivedSummary>> { }
