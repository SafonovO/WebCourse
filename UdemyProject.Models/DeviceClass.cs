using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyProject.Models
{
    public class DeviceClass
    {

        [Key]
        public int Id { get; set; }
        
        
        [Display(Name = "Device Class")]
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
