using Domain.Field;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Fields.Implementation.Context
{
    public class FieldContext : DbContext
    {

        public FieldContext(DbContextOptions<FieldContext> options)
            :base(options)
        {
        }

        public virtual DbSet<Validation> Validation { get; set; }
        public virtual DbSet<TypeField> TypeField { get; set; }
        public virtual DbSet<ValidationInField> ValidationInField { get; set; }
        public virtual DbSet<Field> Field { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TypeField>()
                .HasIndex(u => u.TypeName)
                .IsUnique();
            modelBuilder.Entity<Field>()
                .HasIndex(u => u.Key)
                .IsUnique();
            modelBuilder.Entity<Validation>().HasData(
                  new Validation { 
                     CreateDate = DateTime.Now,
                     DeleteDate = null,
                     Description = "prueba",
                     Id = Guid.NewGuid(),
                     IsDelete = false,
                     ValidationEnum = ValidationsEnum.Equal,
                     Value = "OK"
                  });
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
                return result;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbUpdateConcurrencyException(ex.Message, ex);
            }
            finally
            {
                ChangeTracker.AutoDetectChangesEnabled = true;
            }
        }
    }
}
