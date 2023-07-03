
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monefy.Infraestructure.DataModels
{
    [Table("User")]
    public class UserDataModel
    {
        [Key] public int Id_User { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public Guid Guid_User { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
