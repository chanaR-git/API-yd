using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace hwWebAPI.Models
{

    public class Category
    {
       
        //[Required]
        public int Id { get;set; } 

        //one to one
        public CategoryEnum Kind { get; set; }
        public int KindId { get; set; }
        //many to many
        public List<Product> Products { get; set; }//=new List<Product>();

    }
}
