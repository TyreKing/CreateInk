using CreateInk.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateInk.Context
{
    public class CreateInkContext : DbContext
    {
        public CreateInkContext(DbContextOptions<CreateInkContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var artistBuilder = modelBuilder.Entity<Artist>();
            artistBuilder.Property(x => x.FirstName).HasMaxLength(255).IsRequired();
            artistBuilder.Property(x => x.LastName).HasMaxLength(255).IsRequired();
            artistBuilder.Property(x => x.Description).HasMaxLength(255);
            artistBuilder.Property(x => x.PasswordSalt).IsRequired();
            artistBuilder.Property(x => x.PasswordHash).IsRequired();
            artistBuilder.Property(x => x.Username).IsRequired().HasMaxLength(25);
            artistBuilder.Property(x => x.Email).IsRequired();

            var artBuilder = modelBuilder.Entity<Art>();
            artBuilder.Property(x => x.Description).HasMaxLength(255);
            artBuilder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            artBuilder.Property(x => x.Date).IsRequired();
            artBuilder.HasOne(x => x.Artist).WithMany(x => x.Arts).HasForeignKey(x => x.ArtistId);

            var roleBuilder = modelBuilder.Entity<Role>();
            roleBuilder.Property(x => x.Name).IsRequired();

            var permissionBuilder = modelBuilder.Entity<Permission>();
            permissionBuilder.Property(x => x.Name).IsRequired();

            var rolePermissionsBuilder = modelBuilder.Entity<RolePermissions>();
            rolePermissionsBuilder.HasKey(x => new { x.RoleId, x.PermissionId });
        }

        public virtual DbSet<Art> Arts { get; set; }

        public virtual DbSet<Artist> Artists { get; set; }

        public virtual DbSet<Permission> Permissions { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<RolePermissions> RolePermissions { get; set; }
        
    }
}
