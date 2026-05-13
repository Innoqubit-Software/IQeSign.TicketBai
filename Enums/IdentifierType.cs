namespace IQeSign.TicketBai.Enums;

/// <summary>
/// Tipos de identificación del emisor de una factura recibida (Lista L2 TicketBAI).
/// Usado en <c>ReceivedIssuerInfo.IdentifierType</c>.
/// </summary>
public static class IdentifierType
{
    /// <summary>NIF-IVA (número de identificación fiscal a efectos del IVA).</summary>
    public const string NifIva = "02";

    /// <summary>Pasaporte.</summary>
    public const string Pasaporte = "03";

    /// <summary>Documento oficial de identificación expedido por el país o territorio de residencia.</summary>
    public const string DocumentoOficial = "04";

    /// <summary>Certificado de residencia.</summary>
    public const string CertificadoResidencia = "05";

    /// <summary>Otro documento probatorio.</summary>
    public const string OtroDocumento = "06";
}
