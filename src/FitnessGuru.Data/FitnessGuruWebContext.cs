﻿using FitnessGuru.Models;
using FitnessGuru.Models.Articles;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessGuru.Data
{
    public class FitnessGuruWebContext : IdentityDbContext<FitnessGuruWebUser>
    {
        public FitnessGuruWebContext(DbContextOptions<FitnessGuruWebContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
