using ComSysSoftw_Backend.Infraestructure.Models;
using Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Context;

public class VetDbContext : DbContext
{
    public VetDbContext(DbContextOptions<VetDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Veterinary> Veterinaries { get; set; }

    public virtual DbSet<Pet> Pets { get; set; }

    public virtual DbSet<Meeting> Meetings { get; set; }
    public virtual DbSet<Comment> Comments { get; set; }
    public virtual DbSet<Product> Products{ get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("Server=sql10.freemysqlhosting.net,3306;Uid=sql10628214;Pwd=ISd6XkqXWs;Database=sql10628214;", serverVersion);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Veterinary>().ToTable("Veterinaries");
        modelBuilder.Entity<Veterinary>().HasKey(p => p.Id); //PK
        modelBuilder.Entity<Veterinary>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Veterinary>().Property(c => c.name).IsRequired().HasMaxLength(60);
        modelBuilder.Entity<Veterinary>().Property(c => c.district).IsRequired().HasMaxLength(60);
        modelBuilder.Entity<Veterinary>().Property(c => c.phone_number).IsRequired().HasMaxLength(60);


        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<User>().HasKey(p => p.Id);
        modelBuilder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<User>().Property(c => c.name).IsRequired().HasMaxLength(60);
        modelBuilder.Entity<User>().Property(c => c.email).IsRequired().HasMaxLength(60);
        modelBuilder.Entity<User>().Property(c => c.age).IsRequired().HasMaxLength(60);
        
    }
}
