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


    public DbSet<CoachStat> CoachStats { get; set; }
    public DbSet<Speciality> Specialities { get; set; }
    public DbSet<UserSpeciality> UserSpecialities { get; set; }
    public DbSet<UserExercisePlan> UserExercisePlans { get; set; }
    public DbSet<Matchmaking> Matchmakings { get; set; }
    public DbSet<Improvement> Improvements { get; set; }
    public DbSet<ExercisePlan> ExercisePlans { get; set; }
    public DbSet<NutritionPlan> NutritionPlans { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Diğer ASP.NET Identity özelleştirmeleri
        modelBuilder.Entity<ApplicationUser>()
       .Property(u => u.Birtdate)
       .HasColumnType("date");
        // Başka özelleştirmeler

        modelBuilder.Entity<ExercisePlan>()
        .HasOne(e => e.ApplicationUser)
        .WithMany()
        .HasForeignKey(e => e.Coach_id)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<UserExercisePlan>()
            .HasOne(e => e.ApplicationUser)
            .WithMany()
            .HasForeignKey(e => e.Client_id)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Matchmaking>()
        .HasOne(e => e.ApplicationUser)
        .WithMany()
        .HasForeignKey(e => e.Coach_id)
        .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Matchmaking>()
            .HasOne(e => e.ApplicationUser2)
            .WithMany()
            .HasForeignKey(e => e.Client_id)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<NutritionPlan>()
        .HasOne(e => e.ApplicationUser)
        .WithMany()
        .HasForeignKey(e => e.Coach_id)
        .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<NutritionPlan>()
            .HasOne(e => e.ApplicationUser2)
            .WithMany()
            .HasForeignKey(e => e.Client_id)
            .OnDelete(DeleteBehavior.NoAction);
        
    }
}