
using System.ComponentModel.DataAnnotations;

namespace Monefy.Entities
{
    public class EntityCategory
    {
        public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        [Required]
        [StringLength(20, ErrorMessage = "Name length can't be more than 20.")]
        public string? Name { get; set; }
        [StringLength(50)]
        public string? Description { get; set; }
        [StringLength(50)]
        public string? UrlWeb { get; set; }

    }
}
