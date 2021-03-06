﻿
using System.ComponentModel.DataAnnotations;

namespace TekusApp.Domain.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NIT { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }

    }
}
