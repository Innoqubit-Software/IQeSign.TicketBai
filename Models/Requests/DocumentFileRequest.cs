using IQeSign.TicketBai.Enums;

namespace IQeSign.TicketBai.Models.Requests;

/// <summary>
/// Datos del emisor de la factura TicketBAI.
/// </summary>
public sealed class TicketBaiIssuerInfo
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
    /// Epígrafe de la actividad (solo personas físicas en régimen de estimación objetiva).
    /// <para>Opcional.</para>
    /// </summary>
    public string? TaxCategory { get; set; }
}

/// <summary>
/// Datos de la factura rectificada en TicketBAI.
/// </summary>
public sealed class RectifiedData
{
    /// <summary>
    /// Serie de la factura rectificada.
    /// <para>Opcional.</para>
    /// </summary>
    public string? Serial { get; set; }

    /// <summary>
    /// Número de la factura rectificada.
    /// <para>Opcional.</para>
    /// </summary>
    public string? Number { get; set; }

    /// <summary>
    /// Fecha de la factura rectificada en formato yyyy-MM-dd.
    /// <para>Opcional.</para>
    /// </summary>
    public string? Date { get; set; }

    /// <summary>
    /// Importe base rectificado.
    /// <para>Opcional.</para>
    /// </summary>
    public decimal? BaseRectified { get; set; }

    /// <summary>
    /// Importe del IVA rectificado.
    /// <para>Opcional.</para>
    /// </summary>
    public decimal? VatRectified { get; set; }

    /// <summary>
    /// Importe del recargo de equivalencia rectificado.
    /// <para>Opcional.</para>
    /// </summary>
    public decimal? VatEcRectificate { get; set; }

    /// <summary>
    /// Código de factura rectificativa (Lista L7 TicketBAI).
    /// <para>Valores permitidos: ver <see cref="RectificationCode"/>.</para>
    /// <para>Opcional.</para>
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    /// Tipo de rectificación (Lista L8 TicketBAI).
    /// <para>Valores permitidos: <see cref="RectificationType.PorSustitucion"/> ("S"), <see cref="RectificationType.PorDiferencias"/> ("I").</para>
    /// <para>Opcional.</para>
    /// </summary>
    public string? Type { get; set; }
}

/// <summary>
/// Línea de detalle de la factura TicketBAI.
/// </summary>
public sealed class InvoiceLine
{
    /// <summary>
    /// Descripción del concepto facturado.
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Cantidad de unidades facturadas.
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public decimal Quantity { get; set; }

    /// <summary>
    /// Precio unitario del artículo o servicio.
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public decimal UnitAmount { get; set; }

    /// <summary>
    /// Importe del descuento aplicado.
    /// <para>Opcional.</para>
    /// </summary>
    public decimal? DiscountAmount { get; set; }

    /// <summary>
    /// Porcentaje de IVA aplicado.
    /// <para>Opcional.</para>
    /// </summary>
    public decimal? Vat { get; set; }

    /// <summary>
    /// Porcentaje de recargo de equivalencia aplicado.
    /// <para>Opcional.</para>
    /// </summary>
    public decimal? VatEc { get; set; }

    /// <summary>
    /// Indica si la línea está sujeta a IVA.
    /// <para>Opcional.</para>
    /// </summary>
    public bool? VatSubject { get; set; }

    /// <summary>
    /// Causa de exención del IVA (Lista L10 TicketBAI).
    /// <para>Valores permitidos: ver <see cref="VatCause"/>.</para>
    /// <para>Opcional.</para>
    /// </summary>
    public string? VatCause { get; set; }

    /// <summary>
    /// Clave del régimen especial o trascendencia tributaria (Lista L9 TicketBAI).
    /// <para>Valores permitidos: ver <see cref="TaxKey"/>.</para>
    /// <para>Opcional.</para>
    /// </summary>
    public string? TaxKey { get; set; }
}

/// <summary>
/// Metadatos estadísticos opcionales para identificar la plataforma o usuario origen.
/// </summary>
public sealed class DocumentMetadata
{
    /// <summary>Versión de la plataforma origen. <para>Opcional.</para></summary>
    public string? Version { get; set; }

    /// <summary>Identificador del usuario origen. <para>Opcional.</para></summary>
    public string? User { get; set; }

    /// <summary>Email del usuario origen. <para>Opcional.</para></summary>
    public string? Email { get; set; }

    /// <summary>Nombre de la empresa origen. <para>Opcional.</para></summary>
    public string? Company { get; set; }

    /// <summary>Identificador del tenant origen. <para>Opcional.</para></summary>
    public string? Tenant { get; set; }

    /// <summary>Descripción libre. <para>Opcional.</para></summary>
    public string? Description { get; set; }

    /// <summary>Nombre de la plataforma origen (ej. "BusinessCentral", "Custom"). <para>Opcional.</para></summary>
    public string? Platform { get; set; }
}

/// <summary>
/// Estructura de datos de la factura TicketBAI emitida.
/// Contiene todos los campos necesarios para generar y firmar el XML de la factura.
/// </summary>
public sealed class TicketBaiDocumentFile
{
    /// <summary>
    /// Datos del emisor de la factura.
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public TicketBaiIssuerInfo Issuer { get; set; } = new();

    /// <summary>
    /// Serie de la factura.
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public string Serial { get; set; } = string.Empty;

    /// <summary>
    /// Número de la factura.
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public string Number { get; set; } = string.Empty;

    /// <summary>
    /// Fecha de la factura en formato yyyy-MM-dd.
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public string Date { get; set; } = string.Empty;

    /// <summary>
    /// Nombre o razón social del destinatario/receptor.
    /// <para>Opcional.</para>
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// CIF/NIF del destinatario/receptor.
    /// <para>Opcional.</para>
    /// </summary>
    public string? Nif { get; set; }

    /// <summary>
    /// Dirección del destinatario/receptor.
    /// <para>Opcional.</para>
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// Código postal del destinatario/receptor.
    /// <para>Opcional.</para>
    /// </summary>
    public string? ZipCode { get; set; }

    /// <summary>
    /// Código de país del destinatario (ISO 3166-1 alfa-2, ej. "ES", "FR").
    /// <para>Opcional.</para>
    /// </summary>
    public string? Country { get; set; }

    /// <summary>
    /// Indica si la factura es simplificada (ticket).
    /// <para>Opcional.</para>
    /// </summary>
    public bool? Simplified { get; set; }

    /// <summary>
    /// Tipo de operación (Lista L11 TicketBAI).
    /// <para>Valores permitidos: ver <see cref="OperationTypeEmitted"/>.</para>
    /// <para>Opcional.</para>
    /// </summary>
    public string? OperationType { get; set; }

    /// <summary>
    /// Indica si la factura es rectificativa.
    /// <para>Opcional.</para>
    /// </summary>
    public bool? Rectified { get; set; }

    /// <summary>
    /// Datos de la factura rectificada.
    /// <para>Opcional. Solo se debe rellenar si <c>Rectified</c> es <c>true</c>.</para>
    /// </summary>
    public RectifiedData? RectifiedData { get; set; }

    /// <summary>
    /// Líneas de detalle de la factura.
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public List<InvoiceLine> Lines { get; set; } = new();

    /// <summary>
    /// Importe total de la factura (base + impuestos).
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public decimal TotalInvoice { get; set; }

    /// <summary>
    /// Administración tributaria a la que se presenta la factura.
    /// <para><b>Requerido.</b></para>
    /// <para>Valores permitidos: <see cref="Administration.Alava"/> ("Álava"), <see cref="Administration.Gipuzkoa"/> ("Gipuzkoa"), <see cref="Administration.Bizkaia"/> ("Bizkaia").</para>
    /// </summary>
    public string Administration { get; set; } = string.Empty;
}
