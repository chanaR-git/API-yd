using hwWebAPI.DTO_s;
using hwWebAPI.Models;

namespace hwWebAPI.Services
{
    public interface IProductService
    {
        int CreateProduct(ProductsDTO.CreateProductDTO product);
        bool CreateProducts(List<ProductsDTO.CreateProductDTO> products);
        bool delProd(int id);
        ProductsDTO.ProductsCategoriesDTO? GetProductById(int id);
        List<ProductsDTO.ReadProductsDTO> GetProducts();
        List<Product> GetProductsByCategory(string id);
        List<ProductsDTO.ReadProductsDTO> GetProductsOrdered();
        List<ProductsDTO.ProductsCategoriesDTO> GetProductsWithCategory();
    }
}