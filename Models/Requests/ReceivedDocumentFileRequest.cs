using IQeSign.TicketBai.Enums;

namespace IQeSign.TicketBai.Models.Requests;

/// <summary>
/// Datos del emisor de una factura recibida TicketBAI.
/// </summary>
public sealed class ReceivedIssuerInfo
{
    /// <summary>
    /// Nombre o razón social del emisor.
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// CIF/NIF del emisor.
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public string CifNif { get; set; } = string.Empty;

    /// <summary>
    /// Código de país del emisor (ISO 3166-1 alfa-2, ej. "ES", "FR").
    /// <para>No requerido para emisores nacionales.</para>
    /// </summary>
    public string? Country { get; set; }

    /// <summary>
    /// Tipo de identificación del emisor cuando no tiene NIF español (Lista L2 TicketBAI).
    /// <para>Valores permitidos: ver <see cref="IdentifierType"/>.</para>
    /// <para>Solo cuando el emisor no tiene NIF español.</para>
    /// </summary>
    public string? IdentifierType { get; set; }
}

/// <summary>
/// Detalle de IVA soportado de una factura recibida TicketBAI.
/// </summary>
public sealed class ReceivedVatDetail
{
    /// <summary>
    /// Tipo de compra (Lista L19 TicketBAI).
    /// <para>Valores permitidos: ver <see cref="PurchaseType"/>.</para>
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public string PurchaseType { get; set; } = string.Empty;

    /// <summary>
    /// Indica si la operación está sujeta a inversión del sujeto pasivo (Lista L20 TicketBAI).
    /// <para>Valores permitidos: ver <see cref="ReverseCharge"/>.</para>
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public string ReverseCharge { get; set; } = string.Empty;

    /// <summary>
    /// Porcentaje de IVA aplicado.
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public decimal VatPercent { get; set; }

    /// <summary>
    /// Importe del IVA.
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public decimal VatAmount { get; set; }

    /// <summary>
    /// Base imponible.
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public decimal BaseAmount { get; set; }

    /// <summary>
    /// Importe del IVA soportado.
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public decimal InputVat { get; set; }

    /// <summary>
    /// Importe del IVA deducible.
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public decimal DeductibleVat { get; set; }

    /// <summary>
    /// Porcentaje de compensación en el régimen especial de la agricultura, ganadería y pesca.
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public decimal CompensationSpecialVatPercent { get; set; }

    /// <summary>
    /// Importe de compensación en el régimen especial de la agricultura, ganadería y pesca.
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public decimal CompensationSpecialVatAmount { get; set; }
}

/// <summary>
/// Estructura de datos de una factura recibida TicketBAI.
/// </summary>
public sealed class ReceivedDocumentFile
{
    /// <summary>
    /// Datos del emisor de la factura recibida.
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public ReceivedIssuerInfo Issuer { get; set; } = new();

    /// <summary>
    /// Tipo de operación (Lista L9.2 TicketBAI).
    /// <para>Valores permitidos: ver <see cref="ReceivedOperationType"/>.</para>
    /// <para>Opcional.</para>
    /// </summary>
    public string? OperationType { get; set; }

    /// <summary>
    /// Tipo de factura recibida (Lista L18 TicketBAI).
    /// <para>Valores permitidos: ver <see cref="ReceivedInvoiceType"/>.</para>
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public string InvoiceType { get; set; } = string.Empty;

    /// <summary>
    /// Serie de la factura recibida.
    /// <para>Opcional.</para>
    /// </summary>
    public string? Serial { get; set; }

    /// <summary>
    /// Número de la factura recibida.
    /// <para>Opcional.</para>
    /// </summary>
    public string? Number { get; set; }

    /// <summary>
    /// Ejercicio fiscal de la factura (año en formato yyyy).
    /// <para>Opcional. Año fiscal en formato yyyy.</para>
    /// </summary>
    public int? Exercise { get; set; }

    /// <summary>
    /// Fecha de recepción/contabilización de la factura en formato yyyy-MM-dd.
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public string ReceivedDate { get; set; } = string.Empty;

    /// <summary>
    /// Fecha de la factura en formato yyyy-MM-dd.
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public string InvoiceDate { get; set; } = string.Empty;

    /// <summary>
    /// Cuota de IVA de ventas.
    /// <para>Opcional.</para>
    /// </summary>
    public decimal? SalesVatQuote { get; set; }

    /// <summary>
    /// Nombre o razón social del receptor.
    /// <para>Opcional. Nombre del receptor.</para>
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// CIF/NIF del receptor.
    /// <para>Opcional. NIF del receptor.</para>
    /// </summary>
    public string? Nif { get; set; }

    /// <summary>
    /// Descripción de la operación.
    /// <para>Opcional.</para>
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Indica si la factura es rectificativa.
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public bool Rectified { get; set; }

    /// <summary>
    /// Datos de la factura rectificada.
    /// <para>Opcional. Solo se debe rellenar si <c>Rectified</c> es <c>true</c>.</para>
    /// </summary>
    public RectifiedData? RectifiedData { get; set; }

    /// <summary>
    /// Desglose del IVA soportado de la factura recibida.
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public List<ReceivedVatDetail> VatDetail { get; set; } = new();

    /// <summary>
    /// Base imponible total de la factura.
    /// <para>Opcional.</para>
    /// </summary>
    public decimal? TaxBase { get; set; }

    /// <summary>
    /// Importe total de la factura.
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public decimal TotalInvoice { get; set; }
}
