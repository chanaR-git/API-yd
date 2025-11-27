using System.ComponentModel.DataAnnotations;

namespace hwWebAPI.Models
{
    
    public class Product
    {

        [Required]
        public int Id { get; init; }
        public string? Description { get; set; }
        public string? Picture { get; set; }
        

        [Required,MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        public bool isDeleted { get; set; } = false;
        ////Many To Many
        //public List<Category> Categories { get; set; }//=new List<Category>();

        [Required]
        public Category Category { get; set; }

    }
}
