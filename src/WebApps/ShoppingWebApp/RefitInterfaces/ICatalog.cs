using Refit;
using ShoppingWebApp.Models;

namespace ShoppingWebApp.RefitInterfaces;

public interface ICatalog
{
    [Get("/Catalog")]
    Task<ApiResponse<IEnumerable<CatalogModel>>> GetCatalog();

    [Get("/Catalog/GetProductByCategory/{category}")]
    Task<ApiResponse<IEnumerable<CatalogModel>>> GetCatalogByCategory(string category);

    [Get("/Catalog/{id}")]
    Task<ApiResponse<CatalogModel>> GetCatalog(string id);

    [Post("/Catalog")]
    Task<ApiResponse<CatalogModel>> CreateCatalog(CatalogModel model);
}