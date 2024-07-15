using System.Text.Json;
using Seren.Scripts.Models;

namespace Seren.Scripts.Repositories;

public class SecureDataRepository<T> where T : IIdentifiable
{
    private readonly string _storagePath;
    private Dictionary<string, T> _itemsMap;
    
    protected SecureDataRepository(string storagePath)
    {
        _storagePath = storagePath;
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
    
    public async Task SetByIdAsync(string id, T value)
    {
        if (_itemsMap == null)
            await LoadItemsAsync();

        _itemsMap![id] = value;
        await Flush();
    }

    private async Task LoadItemsAsync()
    {
        if (_storagePath == null)
            return;
        
        var json = await SecureStorage.GetAsync(_storagePath);
        if (json != null)
        {
            var items = JsonSerializer.Deserialize<IEnumerable<T>>(json).ToList();
            _itemsMap = items.ToDictionary(item => item.Id);
        }
        else
        {
            _itemsMap = new Dictionary<string, T>();
        }
    }
    
    private async Task Flush()
    {
        if (_storagePath == null)
            return;
        
        var json = JsonSerializer.Serialize(_itemsMap.Values);
        await SecureStorage.SetAsync(_storagePath, json);
    }
}