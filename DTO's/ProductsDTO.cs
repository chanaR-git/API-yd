using hwWebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace hwWebAPI.DTO_s
{
    //get products
    public class ProductsDTO
    {
        public class ReadProductsDTO
        {

            [Required, MaxLength(20)]
            public string Name { get; set; }
            public string? Description { get; set; }
            public string? Picture { get; set; }
            [Required]
            public int Price { get; set; }
        }


        //get products with categories
        public class ProductsCategoriesDTO
        {

            public string Name { get; set; }
            public string? Description { get; set; }
            public string? Picture { get; set; }
            public int Price { get; set; }
            public string? Category { get; set; }

        }

        //create product
        public class CreateProductDTO
        {
            public string? Description { get; set; }
            public string? Picture { get; set; }


            [Required, MaxLength(20)]
            public string Name { get; set; }

            [Required]
            public int Price { get; set; }

            [Required]
            public int CategoryId { get; set; }
        }


    }
}
