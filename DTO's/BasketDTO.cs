using System.ComponentModel.DataAnnotations;

namespace hwWebAPI.Models
{
    public class CreateBasketDTO
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int productId { get; set; }
    }
}
