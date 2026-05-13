namespace IQeSign.TicketBai.Models.Requests;

/// <summary>
/// Solicitud para cancelar una factura recibida TicketBAI.
/// Endpoint: PUT /api/v2/TicketBai/Received/{id}/Cancel
/// </summary>
public sealed class CancelReceivedRequest
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
