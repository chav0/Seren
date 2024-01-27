using System.Text.Json;
using Seren.Scripts.Models;

namespace Seren.Scripts.Repositories;

public class JsonRepository<T> where T : IIdentifiable
{
    private readonly string _jsonFilePath;
    private Dictionary<string, T> _itemsMap;

    public JsonRepository(string jsonFilePath)
    {
        _jsonFilePath = jsonFilePath;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        if (_itemsMap != null)
            return _itemsMap.Values;

        await LoadItemsAsync();
        return _itemsMap.Values;
    }

    public async Task<T> GetByIdAsync(string id)
    {
        if (_itemsMap == null)
            await LoadItemsAsync();

        return _itemsMap.TryGetValue(id, out var item) ? item : default;
    }

    private async Task LoadItemsAsync()
    {
        await using var stream = await FileSystem.OpenAppPackageFileAsync(_jsonFilePath);
        using var reader = new StreamReader(stream);

        var json = await reader.ReadToEndAsync();
        var items = JsonSerializer.Deserialize<IEnumerable<T>>(json).ToList();

        _itemsMap = items.ToDictionary(item => item.Id);
    }
}