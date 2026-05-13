using IQeSign.TicketBai.Http;
using IQeSign.TicketBai.Models.Requests;
using IQeSign.TicketBai.Models.Responses;

namespace IQeSign.TicketBai.Services;

/// <inheritdoc cref="ITicketBaiService"/>
internal sealed class TicketBaiService : ITicketBaiService
{
    private readonly IQeSignHttpClient _client;

    public TicketBaiService(IQeSignHttpClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<GetUsageResponse> GetUsageAsync(CancellationToken ct = default)
        => _client.GetAsync<GetUsageResponse>("/api/v2/Ticketbai/Usage", ct);

    /// <inheritdoc/>
    public Task<AddDocumentResponse> AddDocumentAsync(AddDocumentRequest request, CancellationToken ct = default)
        => _client.PostAsync<AddDocumentResponse>("/api/v2/TicketBai/Document", request, ct);

    /// <inheritdoc/>
    public Task<GetDocumentResponse> GetDocumentByIdAsync(string id, CancellationToken ct = default)
        => _client.GetAsync<GetDocumentResponse>($"/api/v2/TicketBai/Document/{Uri.EscapeDataString(id)}", ct);

    /// <inheritdoc/>
    public Task<DownloadDocumentResponse> DownloadDocumentAsync(string id, CancellationToken ct = default)
        => _client.GetAsync<DownloadDocumentResponse>($"/api/v2/TicketBai/Document/{Uri.EscapeDataString(id)}/Download", ct);

    /// <inheritdoc/>
    public Task<CancelDocumentResponse> CancelDocumentAsync(string id, CancellationToken ct = default)
        => _client.PutAsync<CancelDocumentResponse>($"/api/v2/TicketBai/Document/{Uri.EscapeDataString(id)}/Cancel", ct);

    /// <inheritdoc/>
    public Task<RetryDocumentResponse> RetryDocumentAsync(string id, CancellationToken ct = default)
        => _client.PutAsync<RetryDocumentResponse>($"/api/v2/TicketBai/Document/{Uri.EscapeDataString(id)}/Retry", ct);

    /// <inheritdoc/>
    public Task<ListDocumentsResponse> ListDocumentsAsync(GetDocumentListRequest? request = null, CancellationToken ct = default)
    {
        var queryParams = new Dictionary<string, string?>
        {
            ["initDate"] = request?.InitDate,
            ["finishDate"] = request?.FinishDate
        };

        return _client.GetAsync<ListDocumentsResponse>("/api/v2/TicketBai/Document/List", queryParams, ct);
    }

    /// <inheritdoc/>
    public Task<AddDocumentResponse> AddZuzenduAsync(string id, AddDocumentRequest request, CancellationToken ct = default)
        => _client.PostAsync<AddDocumentResponse>($"/api/v2/TicketBai/Document/{Uri.EscapeDataString(id)}/Zuzendu", request, ct);

    /// <inheritdoc/>
    public Task<CancelZuzenduResponse> CancelZuzenduAsync(string id, CancellationToken ct = default)
        => _client.PutAsync<CancelZuzenduResponse>($"/api/v2/TicketBai/Document/{Uri.EscapeDataString(id)}/Zuzendu/Cancel", ct);
}
