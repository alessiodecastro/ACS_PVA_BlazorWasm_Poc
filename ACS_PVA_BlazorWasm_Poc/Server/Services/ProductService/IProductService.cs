using ACS_PVA_BlazorWasm_Poc.Shared;

namespace ACS_PVA_BlazorWasm_Poc.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
        Task<Product?> GetProductById(int productId);
        Task<Product> CreateProduct(Product product);
        Task<Product?> UpdateProduct(int productId, Product product);
        Task<bool> DeleteProduct(int productId);
    }
}
