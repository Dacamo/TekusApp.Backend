
using System.ComponentModel.DataAnnotations;

namespace TekusApp.Commands
{
    public class UpdateService
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string HourValue { get; set; }
        [Required]
        public int ClientId { get; set; }
    }
}
