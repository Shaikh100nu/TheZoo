using System.ComponentModel.DataAnnotations;

namespace MVC_crud_sonu_.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; } 
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
    }
}
