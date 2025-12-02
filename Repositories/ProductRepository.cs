using hwWebAPI.Data;
using hwWebAPI.DTO_s;
using hwWebAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static hwWebAPI.DTO_s.ProductsDTO;

namespace hwWebAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        BigBiteContext context;
        public ProductRepository(BigBiteContext context)
        {
            this.context = context;
        }

        #region CRUD

        //get all products with categories
        public List<ProductsCategoriesDTO> GetProductsWithCategory()
        {
            var a = context.Products.Include(p => p.Category.Kind).Where(p => !p.isDeleted)
                .Select(p => new ProductsCategoriesDTO { Description = p.Description, Name = p.Name, Picture = p.Picture, Price = p.Price, Category = p.Category.Kind.Name }).ToList();
            return a;
        }

        //get prod by id
        public ProductsCategoriesDTO? GetProductById(int id)
        {
            var prod = context.Products.Where(p => p.Id == id && !p.isDeleted)
                                        .Select(p => new ProductsCategoriesDTO { Description = p.Description, Name = p.Name, Picture = p.Picture, Price = p.Price, Category = p.Category.Kind.Name }).ToList();
            if (prod.Count > 0)
            {
                return prod[0];
            }
            else
                return null;
        }

        //7.create prod using procedure
        public int CreateProduct(CreateProductDTO p)
        {
            SqlParameter outputParam = new()
            {
                ParameterName = "IdNewRow",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };

            var parameters = new[]
            {
                new SqlParameter("@Name",p.Name),
                new SqlParameter("@Description",p.Description),
                new SqlParameter("@Picture",p.Picture),
                new SqlParameter("@Price",p.Price),
                new SqlParameter("@CategoryId",p.CategoryId),
                outputParam
            };

            context.Database.ExecuteSqlRaw(
            "EXEC CreateProducts_Proc @Name, @Description, @Price, @Picture, @CategoryId, @IdNewRow OUTPUT",
            parameters);

            int newBookId = (int)outputParam.Value;
            return newBookId;
        }

        //delete
        public bool delProd(int id)
        {
            var prod = context.Products.FirstOrDefault(p => p.Id == id);
            if (prod != null)
            {
                prod.isDeleted = true;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        #endregion

        #region extra endpoints
        //getProductByCategory
        public List<Product> GetProductsByCategory(string id)
        {
            var productTags = context.Products
               .Include(x => x.Category)
               .Where(p => p.Category.Id == int.Parse(id) && !p.isDeleted).ToList();

            return productTags;
        }

        //get all products orderedBy Name
        public List<ReadProductsDTO> GetProductsOrdered()
        {
            var a = context.Products.Include(p => p.Category.Kind).OrderBy(a => a.Name).Where(p => !p.isDeleted)
                .Select(p => new ReadProductsDTO { Description = p.Description, Name = p.Name, Picture = p.Picture, Price = p.Price }).ToList();
            return a;
        }

        //get all products without categories
        public List<ReadProductsDTO> GetProducts()
        {
            var products = context.Products.Select(p => new ReadProductsDTO
            { Description = p.Description, Name = p.Name, Picture = p.Picture, Price = p.Price }).ToList();
            return products;
        }

        //7.create many prod-s using transaction
        public bool CreateProducts(List<CreateProductDTO> prods)
        {
            using var transaction = context.Database.BeginTransaction();
            try
            {
                foreach (var item in prods)
                {
                    SqlParameter outputParam = new()
                    {
                        ParameterName = "IdNewRow",
                        SqlDbType = System.Data.SqlDbType.Int,
                        Direction = System.Data.ParameterDirection.Output
                    };
                    var parameters = new[]
                    {
                    new SqlParameter("@Name",item.Name),
                    new SqlParameter("@Description",item.Description),
                    new SqlParameter("@Picture",item.Picture),
                    new SqlParameter("@Price",item.Price),
                    new SqlParameter("@CategoryId",item.CategoryId),
                    outputParam
                    };

                    context.Database.ExecuteSqlRaw(
                    "EXEC CreateProducts_Proc @Name, @Description, @Picture, @Price, @CategoryId,@IdNewRow OUTPUT",
                    parameters);
                }
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return false;
            }
        }

        #endregion







    }
}
    
