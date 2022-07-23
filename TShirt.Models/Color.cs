﻿using System.ComponentModel.DataAnnotations;

namespace TShirt.Models
{
    public class Color
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
