
using AppDev.Application.Common.Interface;
using AppDev.Domain.Entities;
using AppDev.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace AppDev.Infrastructure.Persistence;

public class ApplicationDBContext : DbContext, IApplicationDBContext
{
    private readonly IDateTime _dateTime;

    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options, IDateTime dateTime)
        : base(options)
    {
        _dateTime = dateTime;
    }

    public DbSet<User> Users { get; set; }

    // public DbSet<Department> Department { get; set; }
    // public DbSet<SalaryOrBonus> SalaryOrBonus { get; set; }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<BaseEntity> entry in ChangeTracker
                     .Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.Created = _dateTime.Now;
                    break;

                case EntityState.Modified:
                    entry.Entity.LastModified = _dateTime.Now;
                    break;
                case EntityState.Detached:
                    break;
                case EntityState.Unchanged:
                    break;
                case EntityState.Deleted:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        var result = await base.SaveChangesAsync(cancellationToken);

        return result;
    }
}