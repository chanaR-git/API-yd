using System.ComponentModel.DataAnnotations;

namespace hwWebAPI.Models
{
    public class Basket
    {
        [Required]
        public int Id{ get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        public int productId { get; set; }
        public Product Product { get; set; }
    }
}
