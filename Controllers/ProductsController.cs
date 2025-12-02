using hwWebAPI.Models;
using hwWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static hwWebAPI.DTO_s.ProductsDTO;
//using Microsoft.OpenApi.Extensions;

namespace hwWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
               _productService = productService;
        }

        #region CRUD 
        [HttpGet]
            [Route("GetProductsWithCategories")]
            public IActionResult GetProductsWithCategory()
            {

                return Ok(_productService.GetProductsWithCategory());
            }
            [HttpGet]
            [Route("GetProductById{id}")]
            public IActionResult GetProductById([FromRoute] int id)
            {
                ProductsCategoriesDTO? res = _productService.GetProductById(id);
                if (res !=null)
                {
                    return Ok(res);
                }
                else
                {
                    return BadRequest("no such proudct");
                }
            }
            //procedure
            [HttpPost]
            public IActionResult CreateProduct(CreateProductDTO model)
            {
                try
                {
                    int res = _productService.CreateProduct(model);
                    return Ok(res);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            //משימה 6 שאלה 2
            [HttpDelete("{id}")]
            public IActionResult delProd([FromRoute] int id)
            {

                return Ok(_productService.delProd(id));
            }
        #endregion

        #region extra endpoints
            //GET (DTO)
            [HttpGet]
            public IActionResult getProducts()
            {
                return Ok(_productService.GetProducts());
            }

            //שאילתא 1 
            [HttpGet]
            [Route("GetProdBYCategory/{id}")]
            public IActionResult getProductsByCategory([FromRoute] string idCategory)
            {
                return Ok(_productService.GetProductsByCategory(idCategory));
            }

            //שאילתא 2 +DTO
            [HttpGet]
            [Route("GetProductsOrdered")]
            public IActionResult GetProductsOrdered()
            {
                return Ok(_productService.GetProductsOrdered());
            }


            //transaction
            [HttpPost]
            [Route("create products")]
            public IActionResult CreateProducts([FromBody] List<CreateProductDTO> products)
            {
                try
                {
                    return Ok(_productService.CreateProducts(products));
                }
                catch(Exception ex)
                {
                    return BadRequest("problem");
                } 
                //if(_productService.CreateProducts(products))
                //    return Ok();
                //return BadRequest();
         
            }
        }
    #endregion
}
