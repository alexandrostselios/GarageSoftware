using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using GaragePortalNewUI.Models;
using System;

public class AppTitleMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IMemoryCache _memoryCache;
    private readonly HttpClient _client;

    public AppTitleMiddleware(RequestDelegate next, IMemoryCache memoryCache)
    {
        _next = next;
        _memoryCache = memoryCache;
        _client = new HttpClient();
        _client.BaseAddress = new Uri(@Resources.SettingsResources.Uri);
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!_memoryCache.TryGetValue("AppTitle", out string appTitle))
        {
            var response = await _client.GetAsync("api/GetGarageDetails");
            if (response.IsSuccessStatusCode)
            {
                var garageDetails = await response.Content.ReadAsAsync<IList<GarageDetails>>();
                appTitle = garageDetails.FirstOrDefault()?.Description ?? "Default Title";

                // Cache it for 10 hours
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromHours(10)); // It is called every 10 hours

                _memoryCache.Set("AppTitle", appTitle, cacheOptions);
                
            }
        }
        context.Items["AppTitle"] = appTitle;
        await _next(context);
    }
}