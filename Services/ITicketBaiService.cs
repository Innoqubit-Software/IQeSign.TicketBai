using IQeSign.TicketBai.Models.Requests;
using IQeSign.TicketBai.Models.Responses;

namespace IQeSign.TicketBai.Services;

/// <summary>
/// Servicio para gestionar documentos TicketBAI emitidos a través de la API IQ eSign.
/// </summary>
public interface ITicketBaiService
{
    /// <summary>
    /// Obtiene el resumen de uso de la solución IQ eSign TicketBAI:
    /// número de certificados, documentos procesados y uso por mes.
    /// </summary>
    /// <param name="ct">Token de cancelación.</param>
    Task<GetUsageResponse> GetUsageAsync(CancellationToken ct = default);

    /// <summary>
    /// Envía un nuevo documento TicketBAI (factura emitida) a la hacienda foral.
    /// La API genera el XML, lo firma con el certificado indicado y lo presenta.
    /// </summary>
    /// <param name="request">Datos de la factura y del certificado de firma.</param>
    /// <param name="ct">Token de cancelación.</param>
    /// <returns>Respuesta con el identificador del documento y los avisos de la plataforma.</returns>
    Task<AddDocumentResponse> AddDocumentAsync(AddDocumentRequest request, CancellationToken ct = default);

    /// <summary>
    /// Obtiene el estado y los datos de un documento TicketBAI por su identificador.
    /// </summary>
    /// <param name="id">Identificador del documento en IQ Portal.</param>
    /// <param name="ct">Token de cancelación.</param>
    Task<GetDocumentResponse> GetDocumentByIdAsync(string id, CancellationToken ct = default);

    /// <summary>
    /// Descarga el documento TicketBAI firmado (ZIP con XML) en formato Base64.
    /// </summary>
    /// <param name="id">Identificador del documento en IQ Portal.</param>
    /// <param name="ct">Token de cancelación.</param>
    Task<DownloadDocumentResponse> DownloadDocumentAsync(string id, CancellationToken ct = default);

    /// <summary>
    /// Cancela un documento TicketBAI en la plataforma.
    /// La API genera el XML de cancelación, lo firma y lo presenta a la hacienda foral.
    /// </summary>
    /// <param name="id">Identificador del documento a cancelar.</param>
    /// <param name="ct">Token de cancelación.</param>
    Task<CancelDocumentResponse> CancelDocumentAsync(string id, CancellationToken ct = default);

    /// <summary>
    /// Reintenta el envío de un documento TicketBAI que falló en un intento anterior.
    /// </summary>
    /// <param name="id">Identificador del documento a reintentar.</param>
    /// <param name="ct">Token de cancelación.</param>
    Task<RetryDocumentResponse> RetryDocumentAsync(string id, CancellationToken ct = default);

    /// <summary>
    /// Obtiene el listado de documentos TicketBAI emitidos, con filtro opcional por rango de fechas.
    /// </summary>
    /// <param name="request">Filtros opcionales de fecha (initDate, finishDate en formato yyyy-MM-dd).</param>
    /// <param name="ct">Token de cancelación.</param>
    Task<ListDocumentsResponse> ListDocumentsAsync(GetDocumentListRequest? request = null, CancellationToken ct = default);

    /// <summary>
    /// Envía un Zuzendu (corrección de un documento TicketBAI) a la hacienda foral de Álava o Gipuzkoa.
    /// Solo disponible para las administraciones de Álava y Gipuzkoa.
    /// </summary>
    /// <param name="id">Identificador del documento original a corregir.</param>
    /// <param name="request">Datos del documento de corrección.</param>
    /// <param name="ct">Token de cancelación.</param>
    Task<AddDocumentResponse> AddZuzenduAsync(string id, AddDocumentRequest request, CancellationToken ct = default);

    /// <summary>
    /// Cancela un Zuzendu (corrección) de un documento TicketBAI.
    /// </summary>
    /// <param name="id">Identificador del documento Zuzendu a cancelar.</param>
    /// <param name="ct">Token de cancelación.</param>
    Task<CancelZuzenduResponse> CancelZuzenduAsync(string id, CancellationToken ct = default);
}
