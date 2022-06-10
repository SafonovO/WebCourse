using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyProject.Models
{
    public class Product
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public string Manufacturer { get; set; }

        [Required]
        [Range(1, 10000)]
        public double ListPrice { get; set; }

        [Required]
        [Range(1, 10000)]
        public double Price { get; set; }
        
        [Required]
        [Range(1,10000)]
        public double Price5 { get; set; }
            
        [Required]
        [Range(1, 10000)]
        public double Price10 { get; set; }
        
        public string ImageUrl { get; set; }

        [Required]
        public int CategoryId { get; set; }
        
        public Category Category { get; set; }

        [Required]
        public int DeviceClassId { get; set; }

        public DeviceClass DeviceClass { get; set; }
    }
}
