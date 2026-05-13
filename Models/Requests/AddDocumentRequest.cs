namespace IQeSign.TicketBai.Models.Requests;

/// <summary>
/// Solicitud para enviar un nuevo documento TicketBAI a la hacienda foral.
/// La API generará el XML correspondiente, lo firmará con el certificado indicado y lo presentará.
/// Endpoint: POST /api/v2/TicketBai/Document
/// </summary>
public sealed class AddDocumentRequest
{
    /// <summary>
    /// Datos de la factura a enviar.
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public TicketBaiDocumentFile File { get; set; } = new();

    /// <summary>
    /// Identificador del certificado (.pfx) subido previamente a IQ Portal.
    /// Se usa para firmar el documento TicketBAI.
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public string CertificateId { get; set; } = string.Empty;

    /// <summary>
    /// Contraseña del certificado .pfx.
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public string CertificatePass { get; set; } = string.Empty;

    /// <summary>
    /// Metadatos estadísticos de la plataforma o integración origen.
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public DocumentMetadata? Metadata { get; set; }
}
