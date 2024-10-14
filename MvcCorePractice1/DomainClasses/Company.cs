using System.ComponentModel.DataAnnotations;

namespace MvcCorePractice1.DomainClasses
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
