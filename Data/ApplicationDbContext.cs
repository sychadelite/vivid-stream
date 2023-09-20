using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Vivid.Models;

namespace Vivid.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("MyDB") 
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Watcher> Watcher { get; set; }
        public DbSet<Actor> Actor { get; set; }
    }
}