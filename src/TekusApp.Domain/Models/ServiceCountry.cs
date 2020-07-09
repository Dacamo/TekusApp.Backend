using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TekusApp.Domain.Models
{
    public class ServiceCountry
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CountryId { get; set; }
        [Required]
        public int ServiceId { get; set; }
     

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        [ForeignKey("ServiceId")]
        public virtual Service Service { get; set; }
    }
}
