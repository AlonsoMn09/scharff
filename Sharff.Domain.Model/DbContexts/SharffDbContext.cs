using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sharff.Domain.Model.DbModel;

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

        public virtual DbSet<PgBuffercache> PgBuffercaches { get; set; }
        public virtual DbSet<PgStatStatement> PgStatStatements { get; set; }
        public virtual DbSet<TblGuiaInboundFedex> TblGuiaInboundFedices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

                var connectionString = config.GetConnectionString("DbConnetion");

                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("pg_buffercache")
                .HasPostgresExtension("pg_stat_statements")
                .HasAnnotation("Relational:Collation", "English_United States.1252");

            modelBuilder.Entity<PgBuffercache>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pg_buffercache");

                entity.Property(e => e.Bufferid).HasColumnName("bufferid");

                entity.Property(e => e.Isdirty).HasColumnName("isdirty");

                entity.Property(e => e.PinningBackends).HasColumnName("pinning_backends");

                entity.Property(e => e.Relblocknumber).HasColumnName("relblocknumber");

                entity.Property(e => e.Reldatabase)
                    .HasColumnType("oid")
                    .HasColumnName("reldatabase");

                entity.Property(e => e.Relfilenode)
                    .HasColumnType("oid")
                    .HasColumnName("relfilenode");

                entity.Property(e => e.Relforknumber).HasColumnName("relforknumber");

                entity.Property(e => e.Reltablespace)
                    .HasColumnType("oid")
                    .HasColumnName("reltablespace");

                entity.Property(e => e.Usagecount).HasColumnName("usagecount");
            });

            modelBuilder.Entity<PgStatStatement>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pg_stat_statements");

                entity.Property(e => e.BlkReadTime).HasColumnName("blk_read_time");

                entity.Property(e => e.BlkWriteTime).HasColumnName("blk_write_time");

                entity.Property(e => e.Calls).HasColumnName("calls");

                entity.Property(e => e.Dbid)
                    .HasColumnType("oid")
                    .HasColumnName("dbid");

                entity.Property(e => e.LocalBlksDirtied).HasColumnName("local_blks_dirtied");

                entity.Property(e => e.LocalBlksHit).HasColumnName("local_blks_hit");

                entity.Property(e => e.LocalBlksRead).HasColumnName("local_blks_read");

                entity.Property(e => e.LocalBlksWritten).HasColumnName("local_blks_written");

                entity.Property(e => e.MaxTime).HasColumnName("max_time");

                entity.Property(e => e.MeanTime).HasColumnName("mean_time");

                entity.Property(e => e.MinTime).HasColumnName("min_time");

                entity.Property(e => e.Query).HasColumnName("query");

                entity.Property(e => e.Queryid).HasColumnName("queryid");

                entity.Property(e => e.Rows).HasColumnName("rows");

                entity.Property(e => e.SharedBlksDirtied).HasColumnName("shared_blks_dirtied");

                entity.Property(e => e.SharedBlksHit).HasColumnName("shared_blks_hit");

                entity.Property(e => e.SharedBlksRead).HasColumnName("shared_blks_read");

                entity.Property(e => e.SharedBlksWritten).HasColumnName("shared_blks_written");

                entity.Property(e => e.StddevTime).HasColumnName("stddev_time");

                entity.Property(e => e.TempBlksRead).HasColumnName("temp_blks_read");

                entity.Property(e => e.TempBlksWritten).HasColumnName("temp_blks_written");

                entity.Property(e => e.TotalTime).HasColumnName("total_time");

                entity.Property(e => e.Userid)
                    .HasColumnType("oid")
                    .HasColumnName("userid");
            });

            modelBuilder.Entity<TblGuiaInboundFedex>(entity =>
            {
                entity.HasKey(e => e.AbHdr)
                    .HasName("pk_guia_inbound_fedex");

                entity.ToTable("tbl_guia_inbound_fedex", "sch_courier");

                entity.Property(e => e.AbHdr)
                    .HasMaxLength(256)
                    .HasColumnName("ab_hdr");

                entity.Property(e => e.BillDt)
                    .HasMaxLength(256)
                    .HasColumnName("bill_dt");

                entity.Property(e => e.BillTc)
                    .HasMaxLength(256)
                    .HasColumnName("bill_tc");

                entity.Property(e => e.Broker)
                    .HasMaxLength(256)
                    .HasColumnName("broker");

                entity.Property(e => e.BrokerCity)
                    .HasMaxLength(256)
                    .HasColumnName("broker_city");

                entity.Property(e => e.BrokerCountry)
                    .HasMaxLength(256)
                    .HasColumnName("broker_country");

                entity.Property(e => e.BrokerPhone)
                    .HasMaxLength(256)
                    .HasColumnName("broker_phone");

                entity.Property(e => e.ConsigneeAccount)
                    .HasMaxLength(256)
                    .HasColumnName("consignee_account");

                entity.Property(e => e.ConsigneeAddress1)
                    .HasMaxLength(256)
                    .HasColumnName("consignee_address1");

                entity.Property(e => e.ConsigneeAddress2)
                    .HasMaxLength(256)
                    .HasColumnName("consignee_address2");

                entity.Property(e => e.ConsigneeCity)
                    .HasMaxLength(256)
                    .HasColumnName("consignee_city");

                entity.Property(e => e.ConsigneeCompany)
                    .HasMaxLength(256)
                    .HasColumnName("consignee_company");

                entity.Property(e => e.ConsigneeCountry)
                    .HasMaxLength(256)
                    .HasColumnName("consignee_country");

                entity.Property(e => e.ConsigneeName)
                    .HasMaxLength(256)
                    .HasColumnName("consignee_name");

                entity.Property(e => e.ConsigneePhone)
                    .HasMaxLength(256)
                    .HasColumnName("consignee_phone");

                entity.Property(e => e.ConsigneePostal)
                    .HasMaxLength(256)
                    .HasColumnName("consignee_postal");

                entity.Property(e => e.ConsigneeStPv)
                    .HasMaxLength(256)
                    .HasColumnName("consignee_st_pv");

                entity.Property(e => e.Currency)
                    .HasMaxLength(256)
                    .HasColumnName("currency");

                entity.Property(e => e.CustomsIdrNbr)
                    .HasMaxLength(256)
                    .HasColumnName("customs_idr_nbr");

                entity.Property(e => e.CustomsValue)
                    .HasMaxLength(256)
                    .HasColumnName("customs_value");

                entity.Property(e => e.Description)
                    .HasMaxLength(256)
                    .HasColumnName("description");

                entity.Property(e => e.Dest)
                    .HasMaxLength(256)
                    .HasColumnName("dest");

                entity.Property(e => e.ExportCountry)
                    .HasMaxLength(256)
                    .HasColumnName("export_country");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("fecha_creacion")
                    .HasDefaultValueSql("timezone('America/Lima'::text, now())");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnName("fecha_modificacion")
                    .HasDefaultValueSql("timezone('America/Lima'::text, now())");

                entity.Property(e => e.FreightAmmountUsd)
                    .HasMaxLength(256)
                    .HasColumnName("freight_ammount_usd");

                entity.Property(e => e.Orig)
                    .HasMaxLength(256)
                    .HasColumnName("orig");

                entity.Property(e => e.OriginCountry)
                    .HasMaxLength(256)
                    .HasColumnName("origin_country");

                entity.Property(e => e.ShipDate)
                    .HasMaxLength(256)
                    .HasColumnName("ship_date");

                entity.Property(e => e.ShipperAccount)
                    .HasMaxLength(256)
                    .HasColumnName("shipper_account");

                entity.Property(e => e.ShipperAddress1)
                    .HasMaxLength(256)
                    .HasColumnName("shipper_address1");

                entity.Property(e => e.ShipperAddress2)
                    .HasMaxLength(256)
                    .HasColumnName("shipper_address2");

                entity.Property(e => e.ShipperCity)
                    .HasMaxLength(256)
                    .HasColumnName("shipper_city");

                entity.Property(e => e.ShipperCompany)
                    .HasMaxLength(256)
                    .HasColumnName("shipper_company");

                entity.Property(e => e.ShipperCountry)
                    .HasMaxLength(256)
                    .HasColumnName("shipper_country");

                entity.Property(e => e.ShipperName)
                    .HasMaxLength(256)
                    .HasColumnName("shipper_name");

                entity.Property(e => e.ShipperPhone)
                    .HasMaxLength(256)
                    .HasColumnName("shipper_phone");

                entity.Property(e => e.ShipperPostal)
                    .HasMaxLength(256)
                    .HasColumnName("shipper_postal");

                entity.Property(e => e.ShipperStPv)
                    .HasMaxLength(256)
                    .HasColumnName("shipper_st_pv");

                entity.Property(e => e.Svc)
                    .HasMaxLength(256)
                    .HasColumnName("svc");

                entity.Property(e => e.TotalPackages)
                    .HasMaxLength(256)
                    .HasColumnName("total_packages");

                entity.Property(e => e.TotalWeight)
                    .HasMaxLength(256)
                    .HasColumnName("total_weight");

                entity.Property(e => e.Type)
                    .HasMaxLength(256)
                    .HasColumnName("type");

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("usuario_creacion")
                    .HasDefaultValueSql("CURRENT_USER");

                entity.Property(e => e.UsuarioModificacion)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("usuario_modificacion")
                    .HasDefaultValueSql("CURRENT_USER");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
