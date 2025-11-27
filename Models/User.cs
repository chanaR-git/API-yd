using System.ComponentModel.DataAnnotations;

namespace hwWebAPI.Models
{
    
    public class User
    {
        
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public int Password { get; set; }
    }
}