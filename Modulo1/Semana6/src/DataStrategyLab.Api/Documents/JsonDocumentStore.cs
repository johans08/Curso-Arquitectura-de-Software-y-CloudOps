using System.Text.Json;

namespace DataStrategyLab.Api.Documents;

public interface IDocumentStore<TDocument>
{
    Task UpsertAsync(string id, TDocument document);
    Task<TDocument?> GetAsync(string id);
}

public sealed class JsonDocumentStore<TDocument> : IDocumentStore<TDocument>
{
    private readonly string _folder = Path.Combine(AppContext.BaseDirectory, "documents", typeof(TDocument).Name);
    private readonly JsonSerializerOptions _options = new(JsonSerializerDefaults.Web) { WriteIndented = true };

    public async Task UpsertAsync(string id, TDocument document)
    {
        Directory.CreateDirectory(_folder);
        var path = Path.Combine(_folder, $"{id}.json");
        var json = JsonSerializer.Serialize(document, _options);
        await File.WriteAllTextAsync(path, json);
    }

    public async Task<TDocument?> GetAsync(string id)
    {
        var path = Path.Combine(_folder, $"{id}.json");
        if (!File.Exists(path)) return default;

        var json = await File.ReadAllTextAsync(path);
        return JsonSerializer.Deserialize<TDocument>(json, _options);
    }
}

public sealed record UserProfileDocument(
    string Id,
    string Email,
    string DisplayName,
    Dictionary<string, string> Preferences,
    List<string> Tags
);
