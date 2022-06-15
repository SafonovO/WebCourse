using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyProject.Models
{
    public class User
    {
        [Key]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; } = "user";
    }
}
