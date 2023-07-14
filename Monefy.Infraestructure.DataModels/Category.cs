using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monefy.Infraestructure.DataModels
{
    [Table("Category")]
    public class Category
    {
        public object Expenses;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? UrlWeb { get; set; }
    }
}
