﻿using System.ComponentModel.DataAnnotations;

namespace UdemyCourseRazor.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
       
        public string Description { get; set; }
       
    }

}
