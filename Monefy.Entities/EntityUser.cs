

using System.ComponentModel.DataAnnotations;

namespace Monefy.Entities
{
    public class EntityUser
    {
        public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        [Required]
        [StringLength(20, ErrorMessage = "Name length can't be more than 20.")]
        public string? Name { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Email length can't be more than 30.")]
        public string? Email { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Password length can't be more than 20.")]
        public string? Password { get; set; }

    }
}
