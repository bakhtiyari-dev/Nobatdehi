using EntityModel.Offices;
using EntityModel.Plans;
using EntityModel.Turns;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
        
        //about member
        public DbSet<Citizen> citizens { get; set; }

        // On Model Creating Relation Set
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    builder.Entity<Plan>(c =>
        //    {
        //        c.HasOne(c => c.PlanOption).WithOne().HasForeignKey<PlanOption>(po => po.PlanId);
        //    });
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.; Initial Catalog=Nobatdehi;User ID=loey;Password=Amir_2001; Encrypt=False");
        }
    }

    public class CostumIdentityUser : IdentityUser
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public bool Status { get; set; }

        //Relations

        public int OfficeId { get; set; }
    }
}
