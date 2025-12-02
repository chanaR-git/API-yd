using hwWebAPI.DTO_s;
using hwWebAPI.Models;
using hwWebAPI.Repositories;
using static hwWebAPI.DTO_s.ProductsDTO;

namespace hwWebAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository ;
        public ProductService(IProductRepository repo)
        {
            _repository = repo ;
        }

        #region CRUD
        public List<ProductsCategoriesDTO> GetProductsWithCategory()
        {
            return _repository.GetProductsWithCategory();
        }
        public ProductsCategoriesDTO? GetProductById(int id)
        {
            return _repository.GetProductById(id);
        }
        public int CreateProduct(CreateProductDTO product)
        {
            return _repository.CreateProduct(product);
        }
        public bool delProd(int id)
        {
            return _repository.delProd(id);
        }

        #endregion
        #region extra endpoints
        public List<Product> GetProductsByCategory(string id)
        {
            return _repository.GetProductsByCategory(id);
        }
        public List<ReadProductsDTO> GetProductsOrdered()
        {
            return _repository.GetProductsOrdered();
        }
        public List<ReadProductsDTO> GetProducts()
        {
            return _repository.GetProducts();
        }
        public bool CreateProducts(List<CreateProductDTO> products)
        {
            return _repository.CreateProducts(products);
        }
        #endregion
    }
}
