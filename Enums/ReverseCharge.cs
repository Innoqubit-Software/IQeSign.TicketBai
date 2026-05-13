namespace IQeSign.TicketBai.Enums;

/// <summary>
/// Indica si la operación está sujeta a inversión del sujeto pasivo (Lista L20 TicketBAI).
/// Usado en <c>ReceivedVatDetail.ReverseCharge</c>.
/// </summary>
public static class ReverseCharge
{
    /// <summary>S — Sí, con inversión del sujeto pasivo.</summary>
    public const string Si = "S";

    /// <summary>N — No, sin inversión del sujeto pasivo.</summary>
    public const string No = "N";
}
