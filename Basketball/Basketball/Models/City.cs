using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Basketball.Models
{
    public class City
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }

        [Column(name: "Name", TypeName = "varchar(32)")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Column(name: "CountryId", TypeName = "int")]
        [Required(ErrorMessage = "CountryId is required.")]
        //[ForeignKey("Country")]
        public int CountryId { get; set; }
    }
}
