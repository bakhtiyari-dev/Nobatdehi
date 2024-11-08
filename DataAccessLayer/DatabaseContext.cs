using EntityModel.Offices;
using EntityModel.Plans;
using EntityModel.Turns;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class DatabaseContext : IdentityDbContext<UserManager>
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        //about plan
        DbSet<Plan> Plans { get; set; }

        //about office
        DbSet<Office> Offices { get; set; }

        //about option
        DbSet<PlanOption> PlanOptions { get; set; }
        DbSet<OfficePlanOption> OfficePlanOptions { get; set; }
        DbSet<WeekPlan> WeekPlans { get; set; }

        //about turn
        DbSet<Turn> turns { get; set; }
        DbSet<TurnPool> turnPools { get; set; }
        DbSet<AvailableTurn> availableTurns { get; set; }

        //about member
        DbSet<Citizen> citizens { get; set; }

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

    public class UserManager : IdentityUser
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public bool Status { get; set; }

        //Relations

        public Office Office { get; set; }
    }
}
