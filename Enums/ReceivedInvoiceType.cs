namespace IQeSign.TicketBai.Enums;

/// <summary>
/// Tipos de factura recibida (Lista L18 TicketBAI).
/// Usado en <c>ReceivedDocumentFile.InvoiceType</c>.
/// </summary>
public static class ReceivedInvoiceType
{
    /// <summary>F1 — Factura completa.</summary>
    public const string F1 = "F1";

    /// <summary>F2 — Factura simplificada (ticket).</summary>
    public const string F2 = "F2";

    /// <summary>F3 — Factura emitida en sustitución de facturas simplificadas facturadas y declaradas.</summary>
    public const string F3 = "F3";

    /// <summary>F4 — Asiento resumen de facturas.</summary>
    public const string F4 = "F4";

    /// <summary>F5 — Importaciones (DUA).</summary>
    public const string F5 = "F5";

    /// <summary>F6 — Justificantes contables (otros).</summary>
    public const string F6 = "F6";

    /// <summary>LC — Aduanas — Liquidación complementaria.</summary>
    public const string LC = "LC";
}
