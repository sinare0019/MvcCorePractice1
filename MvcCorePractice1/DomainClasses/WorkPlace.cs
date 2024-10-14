using System.ComponentModel.DataAnnotations;

namespace MvcCorePractice1.DomainClasses
{
    public class WorkPlace
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
