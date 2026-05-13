namespace IQeSign.TicketBai.Models.Requests;

/// <summary>
/// Parámetros de filtro opcionales para listar documentos TicketBAI (emitidos o recibidos).
/// </summary>
public sealed class GetDocumentListRequest
{
    /// <summary>
    /// Fecha de inicio del filtro en formato yyyy-MM-dd.
    /// <para>Opcional.</para>
    /// </summary>
    public string? InitDate { get; set; }

    /// <summary>
    /// Fecha de fin del filtro en formato yyyy-MM-dd.
    /// <para>Opcional.</para>
    /// </summary>
    public string? FinishDate { get; set; }
}
