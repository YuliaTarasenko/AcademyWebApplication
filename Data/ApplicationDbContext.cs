using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using AcademyWebApplication.Models;

namespace AcademyWebApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AcademyWebApplication.Models.Department> Department { get; set; }
        public DbSet<AcademyWebApplication.Models.Faculty> Faculty { get; set; }
        public DbSet<AcademyWebApplication.Models.Group> Group { get; set; }
        public DbSet<AcademyWebApplication.Models.Teacher> Teacher { get; set; }
    }
}
