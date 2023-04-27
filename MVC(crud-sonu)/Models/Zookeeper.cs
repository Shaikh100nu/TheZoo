using System.ComponentModel.DataAnnotations;

namespace MVC_crud_sonu_.Models
{
    public class Zookeeper
    {
        [Key]
        public int Id { get; set; }
        public string? ZookeeperFirstName { get; set; }
        public string? ZookeeperLastName { get; set; }
        public int ZookeeperAge { get; set; }
        public DateTime ZookeeperBirthDate { get; set; }
    }
}
