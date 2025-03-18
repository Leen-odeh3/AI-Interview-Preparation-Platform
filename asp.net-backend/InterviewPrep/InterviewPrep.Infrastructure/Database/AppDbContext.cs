using InterviewPrep.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InterviewPrep.Infrastructure.Database;
public class AppDbContext : IdentityDbContext<User>
{
    public AppDbContext(DbContextOptions<AppDbContext> option):base(option)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Interview>()
            .HasOne(i => i.User)
            .WithMany(u => u.Interviews)
            .HasForeignKey(i => i.UserId);
    }
    public DbSet<Interview> Interviews { get; set; }

}
