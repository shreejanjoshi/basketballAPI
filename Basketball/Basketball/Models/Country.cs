﻿using System.ComponentModel.DataAnnotations;

namespace Basketball.Models
{
    public class Country
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }
    }
}
