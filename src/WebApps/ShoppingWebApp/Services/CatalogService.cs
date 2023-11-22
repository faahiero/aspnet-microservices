using System.Text.Json;
using ShoppingWebApp.Extensions;
using ShoppingWebApp.Models;
using ShoppingWebApp.RefitInterfaces;

namespace ShoppingWebApp.Services;

public class CatalogService : ICatalogService
{
    // private readonly HttpClient _client;
    private readonly ICatalog _catalogApi;

    public CatalogService(ICatalog catalogApi)
    {
        _catalogApi = catalogApi;
    }


    public async Task<IEnumerable<CatalogModel>> GetCatalog()
    {
        // var response = await _client.GetAsync("Catalog");
        // return await response.ReadContentAs<List<CatalogModel>>();

        var response = await _catalogApi.GetCatalog();
        return response.Content;
    }

    public async Task<IEnumerable<CatalogModel>> GetCatalogByCategory(string category)
    {
        // var response = await _client.GetAsync($"/Catalog/GetProductByCategory/{category}");
        // return await response.ReadContentAs<List<CatalogModel>>();

        var response = await _catalogApi.GetCatalogByCategory(category);
        return response.Content;
    }

    public async Task<CatalogModel> GetCatalog(string id)
    {
        // var response = await _client.GetAsync($"/Catalog/{id}");
        // return await response.ReadContentAs<CatalogModel>();

        var response = await _catalogApi.GetCatalog(id);
        return response.Content;
    }

    public async Task<CatalogModel> CreateCatalog(CatalogModel model)
    {
        // var response = await _client.PostAsJson("/Catalog", model);
        // return await response.ReadContentAs<CatalogModel>();

        var response = await _catalogApi.CreateCatalog(model);
        return response.Content;
    }
}