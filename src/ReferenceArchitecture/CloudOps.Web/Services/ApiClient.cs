using System.Net.Http.Json;

namespace CloudOps.Web.Services;

public sealed class ApiClient
{
    private readonly HttpClient _httpClient;

    public ApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IReadOnlyList<ProductViewModel>> GetProductsAsync(CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetFromJsonAsync<IReadOnlyList<ProductViewModel>>("/api/products", cancellationToken)
            ?? Array.Empty<ProductViewModel>();
    }
}

public sealed record ProductViewModel(Guid Id, string Name, string Sku, decimal UnitPrice);
