namespace IQeSign.TicketBai.Models.Requests;

/// <summary>
/// Solicitud para actualizar una factura recibida TicketBAI existente.
/// Endpoint: PUT /api/v2/TicketBai/Received/{id}
/// </summary>
public sealed class UpdateReceivedRequest
{
    /// <summary>
    /// Datos actualizados de la factura recibida.
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
