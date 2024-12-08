using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Basketball.Models
{
    public class Country
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }

        [Column(name: "Name", TypeName = "varchar(32)")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        // Navigation property
        [JsonIgnore] // Prevent circular reference
        public ICollection<City> Cities { get; set; }
    }
}
