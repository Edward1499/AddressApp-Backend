using AddressApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressApp.DAL
{
    public class AddressContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AddressSp>().HasNoKey();
            builder.Entity<GetAllUsersSp>().HasNoKey();
        }
        public AddressContext(DbContextOptions<AddressContext> options) : base(options) { }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressSp> AddressSp { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<GetAllUsersSp> GetAllUsersSp { get; set; }
    }
}
