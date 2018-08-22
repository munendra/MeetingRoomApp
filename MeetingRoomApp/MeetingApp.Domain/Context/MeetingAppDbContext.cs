using MeetingApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MeetingApp.Domain.Context
{
    public class MeetingAppDbContext : DbContext
    {
        public MeetingAppDbContext(DbContextOptions<MeetingAppDbContext> options) : base(options)
        {
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            SetAuditableValue();
            return base.SaveChangesAsync(cancellationToken);
        }
        private void SetAuditableValue()
        {
            foreach (var auditableEntity in ChangeTracker.Entries<IAuditable>())
            {
                if (auditableEntity.State == EntityState.Added ||
                    auditableEntity.State == EntityState.Modified)
                {
                    auditableEntity.Entity.ModifiedAt = DateTime.UtcNow;

                    if (auditableEntity.State == EntityState.Added)
                    {
                        auditableEntity.Entity.CreatedAt = DateTime.UtcNow;
                    }
                }
            }
        }


        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<RoomFacility> RoomFacility { get; set; }

    }
}
