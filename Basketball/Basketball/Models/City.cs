using System.ComponentModel.DataAnnotations;

namespace Basketball.Models
{
    public class City
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "CountryId is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "CountryId must be a positive integer.")]
        public int CountryId { get; set; }
    }
}
