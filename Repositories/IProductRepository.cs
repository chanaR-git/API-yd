using hwWebAPI.DTO_s;
using hwWebAPI.Models;

namespace hwWebAPI.Repositories
{
    public interface IProductRepository
    {
        int CreateProduct(ProductsDTO.CreateProductDTO p);
        bool CreateProducts(List<ProductsDTO.CreateProductDTO> prods);
        bool delProd(int id);
        ProductsDTO.ProductsCategoriesDTO? GetProductById(int id);
        List<ProductsDTO.ReadProductsDTO> GetProducts();
        List<Product> GetProductsByCategory(string id);
        List<ProductsDTO.ReadProductsDTO> GetProductsOrdered();
        List<ProductsDTO.ProductsCategoriesDTO> GetProductsWithCategory();
    }
}