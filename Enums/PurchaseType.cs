namespace IQeSign.TicketBai.Enums;

/// <summary>
/// Tipos de compra para el desglose del IVA soportado (Lista L19 TicketBAI).
/// Usado en <c>ReceivedVatDetail.PurchaseType</c>.
/// </summary>
public static class PurchaseType
{
    /// <summary>C — Compras de bienes corrientes.</summary>
    public const string ComprasBienes = "C";

    /// <summary>G — Gastos.</summary>
    public const string Gastos = "G";

    /// <summary>I — Bienes de inversión.</summary>
    public const string BienesInversion = "I";
}
