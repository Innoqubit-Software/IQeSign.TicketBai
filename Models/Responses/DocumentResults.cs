namespace IQeSign.TicketBai.Models.Responses;

/// <summary>
/// Aviso (warning) devuelto por la plataforma TicketBAI.
/// </summary>
public sealed class TicketBaiWarning
{
    /// <summary>Código del aviso.</summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>Descripción del aviso en castellano.</summary>
    public string Message { get; set; } = string.Empty;

    /// <summary>Descripción del aviso en euskera.</summary>
    public string Azalpena { get; set; } = string.Empty;
}

/// <summary>
/// Resultado de enviar un documento TicketBAI.
/// </summary>
public sealed class SubmitDocumentResult
{
    /// <summary>Identificador del documento creado en IQ Portal.</summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>Avisos devueltos por la plataforma TicketBAI.</summary>
    public List<TicketBaiWarning> Warning { get; set; } = new();
}

/// <summary>
/// Información completa de un documento TicketBAI.
/// </summary>
public sealed class GetDocumentResult
{
    /// <summary>Serie de la factura.</summary>
    public string Serie { get; set; } = string.Empty;

    /// <summary>Número de la factura.</summary>
    public string Number { get; set; } = string.Empty;

    /// <summary>Indica si el documento ha sido procesado por la plataforma TicketBAI.</summary>
    public bool Processed { get; set; }

    /// <summary>Fecha del documento en formato yyyy-MM-dd.</summary>
    public string DocumentDate { get; set; } = string.Empty;

    /// <summary>Huella TicketBAI (identificador único del documento en la plataforma).</summary>
    public string? HuellaTbai { get; set; }

    /// <summary>URL de verificación del documento en la sede electrónica de la hacienda foral.</summary>
    public string? Url { get; set; }

    /// <summary>Código QR que apunta a la URL de verificación.</summary>
    public string? Qr { get; set; }

    /// <summary>Avisos devueltos por la plataforma TicketBAI.</summary>
    public List<TicketBaiWarning> Warning { get; set; } = new();
}

/// <summary>
/// Resultado de descarga del documento TicketBAI firmado (ZIP con XML).
/// </summary>
public sealed class DownloadDocumentResult
{
    /// <summary>Contenido del archivo ZIP en formato Base64.</summary>
    public string File { get; set; } = string.Empty;
}

/// <summary>
/// Resumen de un documento TicketBAI en el listado.
/// </summary>
public sealed class DocumentSummary
{
    /// <summary>Identificador del documento en IQ Portal.</summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>Serie de la factura.</summary>
    public string Serie { get; set; } = string.Empty;

    /// <summary>Número de la factura.</summary>
    public string Number { get; set; } = string.Empty;

    /// <summary>Indica si el documento ha sido procesado por la plataforma TicketBAI.</summary>
    public bool Processed { get; set; }

    /// <summary>Fecha del documento en formato yyyy-MM-dd.</summary>
    public string DocumentDate { get; set; } = string.Empty;

    /// <summary>Huella TicketBAI (identificador único del documento en la plataforma).</summary>
    public string? HuellaTbai { get; set; }

    /// <summary>URL de verificación del documento en la sede electrónica de la hacienda foral.</summary>
    public string? Url { get; set; }
}

/// <summary>Respuesta del endpoint POST TicketBai/Document.</summary>
public sealed class AddDocumentResponse : ApiResponse<SubmitDocumentResult> { }

/// <summary>Respuesta del endpoint PUT TicketBai/Document/{id}/Retry.</summary>
public sealed class RetryDocumentResponse : ApiResponse<SubmitDocumentResult> { }

/// <summary>Respuesta del endpoint GET TicketBai/Document/{id}.</summary>
public sealed class GetDocumentResponse : ApiResponse<GetDocumentResult> { }

/// <summary>Respuesta del endpoint GET TicketBai/Document/{id}/Download.</summary>
public sealed class DownloadDocumentResponse : ApiResponse<DownloadDocumentResult> { }

/// <summary>Respuesta del endpoint PUT TicketBai/Document/{id}/Cancel.</summary>
public sealed class CancelDocumentResponse : ApiResponse { }

/// <summary>Respuesta del endpoint PUT TicketBai/Document/{id}/Zuzendu/Cancel.</summary>
public sealed class CancelZuzenduResponse : ApiResponse { }

/// <summary>Respuesta del endpoint GET TicketBai/Document/List.</summary>
public sealed class ListDocumentsResponse : ApiResponse<List<DocumentSummary>> { }
