using System.ComponentModel.DataAnnotations;

namespace TekusApp.Commands
{
    public class CreateServiceCountry
    {
        [Required]
        public int CountryId { get; set; }
        [Required]
        public int ServiceId { get; set; }
    }
}
