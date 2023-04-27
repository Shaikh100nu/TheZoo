using System.ComponentModel.DataAnnotations;

namespace MVC_crud_sonu_.Models
{
    public class GuestServiceAgent
    {
        [Key]
        public int Id { get; set; }
        public string? ServiceAgentFirstName { get; set; }
        public string? ServiceAgentLastName { get; set; }
        public int ServiceAgentAge { get; set; }
        public DateTime ServiceAgentBirthDate { get; set; }

    }
}
