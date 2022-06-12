using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
        [Display(Name = "List Price")]
        public double ListPrice { get; set; }

        [Required]
        [Range(1, 10000)]
        [Display(Name = "Price for 1-4")]
        public double Price { get; set; }
        
        [Required]
        [Range(1,10000)]
        [Display(Name = "Price for 5-9")]
        public double Price5 { get; set; }
            
        [Required]
        [Range(1, 10000)]
        [Display(Name = "Price for 10+")]
        public double Price10 { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [ValidateNever]
        public Category Category { get; set; }

        [Required]
        [Display(Name = "Device Class")]
        public int DeviceClassId { get; set; }
        [ValidateNever]
        public DeviceClass DeviceClass { get; set; }
    }
}
