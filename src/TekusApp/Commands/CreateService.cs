using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TekusApp.Commands
{
    public class CreateService
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string HourValue { get; set; }
        [Required]
        public int ClientId { get; set; }
    }
}
