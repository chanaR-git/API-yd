using System.ComponentModel.DataAnnotations;

namespace hwWebAPI.Models
{
    public class CategoryEnum
    {
        private int identity =0;
        [Required]
        public int Id { get; set; }

        [MinLength(3)]
        public string Name { get; set; }

        //public CategoryEnum(string name)
        //{
        //    Id = identity++;
        //    Name = name;
        //}
    }
}
