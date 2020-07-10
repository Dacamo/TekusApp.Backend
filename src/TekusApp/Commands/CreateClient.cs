using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TekusApp.Commands
{
    public class CreateClient
    {
        [Required(ErrorMessage = "Please enter NIT")]
        public string NIT { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
