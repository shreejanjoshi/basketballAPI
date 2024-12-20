﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Basketball.Models
{
    public class BasketballClub
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }

        [Column(name: "Name", TypeName = "varchar(32)")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Column(name: "CityId", TypeName = "int")]
        [Required(ErrorMessage = "CityId is required.")]
        [ForeignKey("City")]
        public int CityId { get; set; }

        // Navigation Properties
        //[JsonIgnore] // Prevent circular reference
        public City City { get; set; }
    }
}
