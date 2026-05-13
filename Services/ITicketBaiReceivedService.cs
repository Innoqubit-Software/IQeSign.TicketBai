using IQeSign.TicketBai.Models.Requests;
using IQeSign.TicketBai.Models.Responses;

namespace IQeSign.TicketBai.Services;

/// <summary>
/// Servicio para gestionar facturas recibidas TicketBAI a través de la API IQ eSign.
/// </summary>
public interface ITicketBaiReceivedService
{
    /// <summary>
    /// Registra una nueva factura recibida en la plataforma TicketBAI.
    /// </summary>
    /// <param name="request">Datos de la factura recibida y del certificado de firma.</param>
    /// <param name="ct">Token de cancelación.</param>
    /// <returns>Respuesta con el identificador de la factura recibida creada.</returns>
    Task<AddReceivedResponse> AddReceivedAsync(AddReceivedRequest request, CancellationToken ct = default);

    /// <summary>
    /// Cancela una factura recibida previamente registrada en la plataforma TicketBAI.
    /// </summary>
    /// <param name="id">Identificador de la factura recibida en IQ Portal.</param>
    /// <param name="request">Identificador y contraseña del certificado de firma.</param>
    /// <param name="ct">Token de cancelación.</param>
    Task<CancelReceivedResponse> CancelReceivedAsync(string id, CancelReceivedRequest request, CancellationToken ct = default);

    /// <summary>
    /// Consulta el estado de una factura recibida en la hacienda foral.
    /// </summary>
    /// <param name="id">Identificador de la factura recibida en IQ Portal.</param>
    /// <param name="request">Identificador y contraseña del certificado de firma.</param>
    /// <param name="ct">Token de cancelación.</param>
    Task<CheckReceivedResponse> CheckReceivedAsync(string id, CheckReceivedRequest request, CancellationToken ct = default);

    /// <summary>
    /// Actualiza los datos de una factura recibida existente en la plataforma TicketBAI.
    /// </summary>
    /// <param name="id">Identificador de la factura recibida en IQ Portal.</param>
    /// <param name="request">Datos actualizados de la factura recibida y del certificado de firma.</param>
    /// <param name="ct">Token de cancelación.</param>
    Task<UpdateReceivedResponse> UpdateReceivedAsync(string id, UpdateReceivedRequest request, CancellationToken ct = default);

    /// <summary>
    /// Obtiene el listado de facturas recibidas TicketBAI, con filtro opcional por rango de fechas.
    /// </summary>
    /// <param name="request">Filtros opcionales de fecha (initDate, finishDate en formato yyyy-MM-dd).</param>
    /// <param name="ct">Token de cancelación.</param>
    Task<ListReceivedResponse> ListReceivedAsync(GetDocumentListRequest? request = null, CancellationToken ct = default);
}
