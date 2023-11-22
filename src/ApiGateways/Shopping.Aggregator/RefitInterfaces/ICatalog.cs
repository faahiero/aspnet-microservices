using Refit;
using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.RefitInterfaces;

public interface ICatalog
{
    [Get("/api/v1/Catalog")]
    Task<IEnumerable<CatalogModel>> GetCatalog();

    [Get("/api/v1/Catalog/GetProductByCategory/{category}")]
    Task<IEnumerable<CatalogModel>> GetCatalogByCategory(string category);

    [Get("/api/v1/Catalog/{id}")]
    Task<CatalogModel> GetCatalog(string id);
}