namespace IQeSign.TicketBai.Enums;

/// <summary>
/// Causas de exención del IVA (Lista L10 TicketBAI).
/// Usado en <c>InvoiceLine.VatCause</c>.
/// </summary>
public static class VatCause
{
    /// <summary>E1 — Exenta por el artículo 20 de la Norma Foral del IVA.</summary>
    public const string E1 = "E1";

    /// <summary>E2 — Exenta por el artículo 21 de la Norma Foral del IVA.</summary>
    public const string E2 = "E2";

    /// <summary>E3 — Exenta por el artículo 22 de la Norma Foral del IVA.</summary>
    public const string E3 = "E3";

    /// <summary>E4 — Exenta por los artículos 23 y 24 de la Norma Foral del IVA.</summary>
    public const string E4 = "E4";

    /// <summary>E5 — Exenta por el artículo 25 de la Norma Foral del IVA.</summary>
    public const string E5 = "E5";

    /// <summary>E6 — Exenta por otra causa.</summary>
    public const string E6 = "E6";

    /// <summary>OT — No sujeta por el artículo 7 de la Norma Foral del IVA u otras causas.</summary>
    public const string OT = "OT";

    /// <summary>RL — No sujeta por reglas de localización.</summary>
    public const string RL = "RL";

    /// <summary>IE — No sujeta y no localizada (importes exentos o no sujetos sin derecho a deducción).</summary>
    public const string IE = "IE";

    /// <summary>VT — No sujeta por ventas a distancia y determinadas entregas.</summary>
    public const string VT = "VT";
}
