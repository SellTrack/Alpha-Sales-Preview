using System.Reflection.Emit;
using AlphaSales.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlphaSales.DataAccess.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Corporation> Corporations { get; set; }
    public DbSet<LanguagePack> LanguagePacks { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Diğer ASP.NET Identity özelleştirmeleri


        modelBuilder.Entity<Client>()
    .HasOne(c => c.ApplicationUser)
    .WithMany()
    .HasForeignKey(c => c.Client_Owner_ID)
    .IsRequired(false)
    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Client>()
            .HasOne(c => c.ApplicationUser2)
            .WithMany()
            .HasForeignKey(c => c.Client_QC_Caller_ID)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
            

        modelBuilder.Entity<Corporation>().HasData(
            new Corporation { CorporationID = 1, Name = "Alpha", Adress = "AA", City = "Amasya" },
            new Corporation { CorporationID = 2, Name = "Beta", Adress = "bb", City = "Akasya" },
            new Corporation { CorporationID = 3, Name = "Charlie", Adress = "cc", City = "Alaçam" }
        );

        // Başka özelleştirmeler
    }
}