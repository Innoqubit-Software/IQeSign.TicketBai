namespace IQeSign.TicketBai.Models.Requests;

/// <summary>
/// Solicitud para registrar una nueva factura recibida en TicketBAI.
/// Endpoint: POST /api/v2/TicketBai/Received
/// </summary>
public sealed class AddReceivedRequest
{
    /// <summary>
    /// Datos de la factura recibida.
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public ReceivedDocumentFile File { get; set; } = new();

    /// <summary>
    /// Identificador del certificado (.pfx) subido previamente a IQ Portal.
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public string CertificateId { get; set; } = string.Empty;

    /// <summary>
    /// Contraseña del certificado .pfx.
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public string CertificatePass { get; set; } = string.Empty;

    /// <summary>
    /// Metadatos estadísticos opcionales de la plataforma o integración origen.
    /// <para>Opcional.</para>
    /// </summary>
    public DocumentMetadata? Metadata { get; set; }
}
