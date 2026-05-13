namespace IQeSign.TicketBai.Enums;

/// <summary>
/// Tipos de operación para documentos emitidos (Lista L11 TicketBAI).
/// Usado en <c>TicketBaiDocumentFile.OperationType</c>.
/// </summary>
public static class OperationTypeEmitted
{
    /// <summary>S1 — Sin inversión del sujeto pasivo.</summary>
    public const string SinInversion = "S1";

    /// <summary>S2 — Con inversión del sujeto pasivo.</summary>
    public const string ConInversion = "S2";
}
