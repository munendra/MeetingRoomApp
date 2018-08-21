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
                    auditableEntity.Entity.Modified = DateTime.UtcNow;

                    if (auditableEntity.State == EntityState.Added)
                    {
                        auditableEntity.Entity.Created = DateTime.UtcNow;
                    }
                }
            }
        }

    }
}
