namespace IQeSign.TicketBai.Enums;

/// <summary>
/// Tipos de rectificación de una factura (Lista L8 TicketBAI).
/// Usado en <c>RectifiedData.Type</c>.
/// </summary>
public static class RectificationType
{
    /// <summary>Rectificación por sustitución.</summary>
    public const string PorSustitucion = "S";

    /// <summary>Rectificación por diferencias.</summary>
    public const string PorDiferencias = "I";
}
