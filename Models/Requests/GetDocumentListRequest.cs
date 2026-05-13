namespace IQeSign.TicketBai.Models.Requests;

/// <summary>
/// Parámetros de filtro para listar documentos TicketBAI (emitidos o recibidos).
/// </summary>
public sealed class GetDocumentListRequest
{
    /// <summary>
    /// Fecha de inicio del filtro en formato yyyy-MM-dd.
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public string InitDate { get; set; } = string.Empty;

    /// <summary>
    /// Fecha de fin del filtro en formato yyyy-MM-dd.
    /// <para><b>Requerido.</b></para>
    /// </summary>
    public string FinishDate { get; set; } = string.Empty;
}
