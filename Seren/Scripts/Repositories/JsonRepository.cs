using System.Text.Json;
using System.Text.Json.Serialization;
using Seren.Scripts.Models;

namespace Seren.Scripts.Repositories;

public class JsonRepository<T> where T : IIdentifiable
{
    private readonly string _jsonFilePath;
    private Dictionary<string, T> _itemsMap;
    
    protected JsonRepository(string jsonFilePath)
    {
        _jsonFilePath = jsonFilePath;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        if (_itemsMap != null)
            return _itemsMap.Values;

        await LoadItemsAsync();
        return _itemsMap!.Values;
    }

    public async Task<T> GetByIdAsync(string id)
    {
        if (_itemsMap == null)
            await LoadItemsAsync();

        return _itemsMap!.TryGetValue(id, out var item) ? item : default;
    }

    public async Task LoadItemsAsync()
    {
        if (_jsonFilePath == null)
            return;
        
        await using var stream = await FileSystem.OpenAppPackageFileAsync(_jsonFilePath);
        using var reader = new StreamReader(stream);
        
        var options = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter() }
        };

        var json = await reader.ReadToEndAsync();
        var items = JsonSerializer.Deserialize<IEnumerable<T>>(json, options).ToList();

        _itemsMap = items.ToDictionary(item => item.Id);
    }
}