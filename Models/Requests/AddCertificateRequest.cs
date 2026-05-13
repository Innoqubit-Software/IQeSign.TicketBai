namespace IQeSign.TicketBai.Models.Requests;

/// <summary>
/// Solicitud para añadir un certificado digital (.pfx) a IQ Portal.
/// El certificado se usa para firmar los documentos TicketBAI enviados a la hacienda foral.
/// Los certificados son compartidos entre las soluciones IQ eSign Facturae, ePDF, TicketBAI y VeriFactu.
/// </summary>
public sealed class AddCertificateRequest
{
    /// <summary>
    /// Contenido del archivo .pfx en formato Base64.
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public string File { get; set; } = string.Empty;

    /// <summary>
    /// Nombre descriptivo para identificar el certificado en IQ Portal.
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public string Name { get; set; } = string.Empty;
}
