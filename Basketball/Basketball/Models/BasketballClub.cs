using System.ComponentModel.DataAnnotations;

namespace Basketball.Models
{
    public class BasketballClub
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "CityId is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "CityId must be a positive integer.")]
        public int CityId { get; set; } 
    }
}
