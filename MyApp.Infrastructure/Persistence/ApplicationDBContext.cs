using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Persistence
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<Activity> Activitys { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Blotter> Blotters { get; set; }
        public DbSet<BlotterDefendant> BlottersDefendant { get; set; }
        public DbSet<Complainant> Complainants { get; set; }
        public DbSet<Defendant> Defendant { get; set; }
        public DbSet<Logs> Logs { get; set; }
        public DbSet<Ordinance> Ordinances { get;set; }
        public DbSet<Resident> Residents { get; set; }

    }
}
