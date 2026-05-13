namespace IQeSign.TicketBai.Models.Requests;

/// <summary>
/// Solicitud para comprobar el estado de una factura recibida TicketBAI en la hacienda foral.
/// Endpoint: PUT /api/v2/TicketBai/Received/{id}/Check
/// </summary>
public sealed class CheckReceivedRequest
{
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
}
