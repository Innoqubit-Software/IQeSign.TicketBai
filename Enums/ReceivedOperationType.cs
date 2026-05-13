namespace IQeSign.TicketBai.Enums;

/// <summary>
/// Tipos de operación para facturas recibidas (Lista L9.2 TicketBAI).
/// Usado en <c>ReceivedDocumentFile.OperationType</c>.
/// </summary>
public static class ReceivedOperationType
{
    /// <summary>01 — Adquisición de bienes y servicios corrientes.</summary>
    public const string AdquisicionBienesServicios = "01";

    /// <summary>02 — Adquisición de bienes de inversión.</summary>
    public const string AdquisicionBienesInversion = "02";

    /// <summary>03 — Importación de bienes corrientes.</summary>
    public const string ImportacionBienes = "03";

    /// <summary>04 — Importación de bienes de inversión.</summary>
    public const string ImportacionBienesInversion = "04";

    /// <summary>05 — Adquisición sujeta y no exenta de IVA (inversión del sujeto pasivo).</summary>
    public const string InversionSujetoPasivo = "05";

    /// <summary>07 — IVA pendiente de liquidar (devengo en certificaciones de obra).</summary>
    public const string IvaPendienteCertificaciones = "07";

    /// <summary>08 — IVA pendiente de liquidar (tracto sucesivo).</summary>
    public const string IvaPendienteTracto = "08";

    /// <summary>09 — Adquisiciones intracomunitarias de bienes.</summary>
    public const string AdquisicionesIntracomunitarias = "09";

    /// <summary>12 — Prestaciones de servicios intracomunitarias.</summary>
    public const string ServiciosIntracomunitarios = "12";

    /// <summary>13 — Operaciones de arrendamiento de local de negocio.</summary>
    public const string ArrendamientoLocal = "13";
}
