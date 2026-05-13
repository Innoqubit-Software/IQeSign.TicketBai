namespace IQeSign.TicketBai.Enums;

/// <summary>
/// Claves del régimen especial o trascendencia tributaria de la operación (Lista L9 TicketBAI).
/// Usado en <c>InvoiceLine.TaxKey</c>.
/// </summary>
public static class TaxKey
{
    /// <summary>01 — Régimen general.</summary>
    public const string RegimenGeneral = "01";

    /// <summary>02 — Exportación.</summary>
    public const string Exportacion = "02";

    /// <summary>03 — Operaciones a las que se aplica el régimen especial de bienes usados, objetos de arte, antigüedades y objetos de colección.</summary>
    public const string BienesUsados = "03";

    /// <summary>04 — Régimen especial del oro de inversión.</summary>
    public const string OroInversion = "04";

    /// <summary>05 — Régimen especial de las agencias de viajes.</summary>
    public const string AgenciasViajes = "05";

    /// <summary>06 — Régimen especial grupo de entidades en IVA (Nivel Avanzado).</summary>
    public const string GrupoEntidades = "06";

    /// <summary>07 — Régimen especial del criterio de caja.</summary>
    public const string CriterioCaja = "07";

    /// <summary>08 — Operaciones sujetas al IPSI / IGIC (Impuesto sobre la Producción, los Servicios y la Importación / Impuesto General Indirecto Canario).</summary>
    public const string IpsiIgic = "08";

    /// <summary>09 — Adquisiciones intracomunitarias de bienes y prestaciones de servicios.</summary>
    public const string AdquisicionesIntracomunitarias = "09";

    /// <summary>10 — Cobros por cuenta de terceros de honorarios profesionales o de derechos derivados de la propiedad industrial, de autor u otros.</summary>
    public const string CobrosHonorariosTProfesionales = "10";

    /// <summary>11 — Operaciones de arrendamiento de local de negocio sujetas a retención.</summary>
    public const string ArrendamientoConRetencion = "11";

    /// <summary>12 — Operaciones de arrendamiento de local de negocio no sujetas a retención.</summary>
    public const string ArrendamientoSinRetencion = "12";

    /// <summary>13 — Operaciones de arrendamiento de local de negocio sujetas y no sujetas a retención.</summary>
    public const string ArrendamientoMixto = "13";

    /// <summary>14 — Factura con IVA pendiente de devengo en certificaciones de obra cuyo destinatario sea una Administración Pública.</summary>
    public const string IvaPendienteAdminPublica = "14";

    /// <summary>15 — Factura con IVA pendiente de devengo en operaciones de tracto sucesivo.</summary>
    public const string IvaPendienteTractoSucesivo = "15";

    /// <summary>51 — Operaciones en recargo de equivalencia.</summary>
    public const string RecargoEquivalencia = "51";

    /// <summary>52 — Operaciones en régimen simplificado.</summary>
    public const string RegimenSimplificado = "52";

    /// <summary>53 — Operaciones realizadas por personas físicas o entidades en régimen de atribución de rentas en actividades agrícolas, ganaderas, forestales o pesqueras.</summary>
    public const string AtribucionRentasAgropecuaria = "53";
}
