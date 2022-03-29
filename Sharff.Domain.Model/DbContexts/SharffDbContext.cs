using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Sharff.Domain.Model.DbModel;

#nullable disable

namespace Sharff.Domain.Model.DbContexts
{
    public partial class SharffDbContext : DbContext
    {
        public SharffDbContext()
        {
        }

        public SharffDbContext(DbContextOptions<SharffDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblLog> TblLogs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Spanish_Peru.1252");

            modelBuilder.Entity<TblLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("log_pkey");

                entity.ToTable("TblLog");

                entity.Property(e => e.LogId)
                    .HasColumnName("log_id")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(null, null, null, 999999L, null, null);

                entity.Property(e => e.LogFecha).HasColumnName("log_fecha");

                entity.Property(e => e.LogMessage).HasColumnName("log_message");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
