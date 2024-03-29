﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UdemyProject.Models;

namespace UdemyProject.DataAccess
{
    public class ApplicationDbContext: IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DeviceClass> DeviceClasses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
