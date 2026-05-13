namespace IQeSign.TicketBai.Enums;

/// <summary>
/// Códigos de factura rectificativa (Lista L7 TicketBAI).
/// Usado en <c>RectifiedData.Code</c>.
/// </summary>
public static class RectificationCode
{
    /// <summary>R1 — Factura rectificativa (Art. 80.1, 80.2 y 80.6 y error fundado en derecho).</summary>
    public const string R1 = "R1";

    /// <summary>R2 — Factura rectificativa (Art. 80.3).</summary>
    public const string R2 = "R2";

    /// <summary>R3 — Factura rectificativa (Art. 80.4).</summary>
    public const string R3 = "R3";

    /// <summary>R4 — Factura rectificativa (Resto).</summary>
    public const string R4 = "R4";

    /// <summary>R5 — Factura rectificativa en facturas simplificadas.</summary>
    public const string R5 = "R5";
}
