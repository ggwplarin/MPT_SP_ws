using System;
using System.Data.Entity;
using WSR.dtos;

namespace WSR.DBContexts
{
    public class DataContext:DbContext
    {
        public DataContext() : base("DefaultConnection")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Auth> AuthLog { get; set; }
    }
}