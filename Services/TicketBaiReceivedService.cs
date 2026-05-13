using IQeSign.TicketBai.Http;
using IQeSign.TicketBai.Models.Requests;
using IQeSign.TicketBai.Models.Responses;

namespace IQeSign.TicketBai.Services;

/// <inheritdoc cref="ITicketBaiReceivedService"/>
internal sealed class TicketBaiReceivedService : ITicketBaiReceivedService
{
    private readonly IQeSignHttpClient _client;

    public TicketBaiReceivedService(IQeSignHttpClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<AddReceivedResponse> AddReceivedAsync(AddReceivedRequest request, CancellationToken ct = default)
        => _client.PostAsync<AddReceivedResponse>("/api/v2/TicketBai/Received", request, ct);

    /// <inheritdoc/>
    public Task<CancelReceivedResponse> CancelReceivedAsync(string id, CancelReceivedRequest request, CancellationToken ct = default)
        => _client.PutAsync<CancelReceivedResponse>($"/api/v2/TicketBai/Received/{Uri.EscapeDataString(id)}/Cancel", request, ct);

    /// <inheritdoc/>
    public Task<CheckReceivedResponse> CheckReceivedAsync(string id, CheckReceivedRequest request, CancellationToken ct = default)
        => _client.PutAsync<CheckReceivedResponse>($"/api/v2/TicketBai/Received/{Uri.EscapeDataString(id)}/Check", request, ct);

    /// <inheritdoc/>
    public Task<UpdateReceivedResponse> UpdateReceivedAsync(string id, UpdateReceivedRequest request, CancellationToken ct = default)
        => _client.PutAsync<UpdateReceivedResponse>($"/api/v2/TicketBai/Received/{Uri.EscapeDataString(id)}", request, ct);

    /// <inheritdoc/>
    public Task<ListReceivedResponse> ListReceivedAsync(GetDocumentListRequest? request = null, CancellationToken ct = default)
    {
        var queryParams = new Dictionary<string, string?>
        {
            ["initDate"] = request?.InitDate,
            ["finishDate"] = request?.FinishDate
        };

        return _client.GetAsync<ListReceivedResponse>("/api/v2/TicketBai/Received/List", queryParams, ct);
    }
}
