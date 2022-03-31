﻿using System;
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

        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<TblLog> TblLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=SharffDb;Port=5433;User Id=postgres;Password=12;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Spanish_Peru.1252");

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("logs");

                entity.Property(e => e.Exception).HasColumnName("exception");

                entity.Property(e => e.Level)
                    .HasMaxLength(50)
                    .HasColumnName("level");

                entity.Property(e => e.MachineName).HasColumnName("machine_name");

                entity.Property(e => e.Message).HasColumnName("message");

                entity.Property(e => e.MessageTemplate).HasColumnName("message_template");

                entity.Property(e => e.Properties)
                    .HasColumnType("jsonb")
                    .HasColumnName("properties");

                entity.Property(e => e.PropsTest)
                    .HasColumnType("json")
                    .HasColumnName("props_test");

                entity.Property(e => e.RaiseDate).HasColumnName("raise_date");
            });

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
