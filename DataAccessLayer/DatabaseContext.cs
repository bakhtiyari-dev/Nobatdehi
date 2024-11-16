using EntityModel.Offices;
using EntityModel.Plans;
using EntityModel.Turns;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EntityModel.Users;

namespace DataAccessLayer
{
    public class DatabaseContext : IdentityDbContext<CostumIdentityUser>
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        //about plan
        public DbSet<Plan> Plans { get; set; }
        
        //about office
        public DbSet<Office> Offices { get; set; }
        
        //about option
        public DbSet<PlanOption> PlanOptions { get; set; }
        public DbSet<OfficePlanOption> OfficePlanOptions { get; set; }
        public DbSet<WeekPlan> WeekPlans { get; set; }
        
        //about turn
        public DbSet<Turn> turns { get; set; }
        public DbSet<TurnPool> turnPools { get; set; }
        public DbSet<AvailableTurn> availableTurns { get; set; }
        public DbSet<DesabledTurn> desabledTurns { get; set; }
        
        //about member
        public DbSet<Citizen> citizens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Plan>()
                .HasMany(c => c.dependentPlans)
                .WithMany(c => c.headPlans)
                .UsingEntity<Dictionary<string, object>>(
                    "PlanDependencies",
                    j => j.HasOne<Plan>().WithMany().HasForeignKey("Dependencies"),
                    j => j.HasOne<Plan>().WithMany().HasForeignKey("PlanId"));

            modelBuilder.Entity<CostumIdentityUser>()
                .HasOne(u => u.Office)
                .WithMany(o => o.Users)
                .HasForeignKey(u => u.OfficeId)
                .IsRequired(false);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.; Initial Catalog=Nobatdehi;User ID=loey;Password=Amir_2001; Encrypt=False");
        }
    }
}
