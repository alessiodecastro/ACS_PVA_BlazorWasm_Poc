using ACS_PVA_BlazorWasm_Poc.Shared;

namespace ACS_PVA_BlazorWasm_Poc.Client.Services.ProductService
{
    public interface IProductService
    {
        List<Product> Products { get; set; }
        Task GetProducts();
        Task<Product?> GetProductById(int id);
        Task CreateProduct(Product product);
        Task UpdateProduct(int id, Product product);
        Task DeleteProduct(int id);
    }
}
