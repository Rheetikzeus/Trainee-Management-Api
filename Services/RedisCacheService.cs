
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace TraineeManagement.Services;

public class RedisCacheService
{

    private readonly IDistributedCache _cache;
    
    public RedisCacheService(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task SetKeyAsync<T>(string key, T t)
    {
        var cacheOptions = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30), 
            SlidingExpiration = TimeSpan.FromMinutes(5)
        };
        await _cache.SetStringAsync(key, JsonSerializer.Serialize(t), cacheOptions);
    }

    public async Task<T?> GetKeyAsync<T>(string key)
    {
        string? cachedResponse = await _cache.GetStringAsync(key);
        return cachedResponse == null ? default : JsonSerializer.Deserialize<T>(cachedResponse);
    }
    
    public async Task DeleteKeyAsync(string key)
    {
        await _cache.RemoveAsync(key);
    }

    public async Task<bool> ExistKeyAsync(string key)
    {
        return await _cache.GetAsync(key) != null;
    }
}