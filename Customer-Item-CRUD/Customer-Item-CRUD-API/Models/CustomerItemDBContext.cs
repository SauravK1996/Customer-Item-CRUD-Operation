using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Customer_Item_CRUD_API.Models
{
    public partial class CustomerItemDBContext : DbContext
    {
        public CustomerItemDBContext()
        {
        }

        public CustomerItemDBContext(DbContextOptions<CustomerItemDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tabcust> Tabcusts { get; set; }
        public virtual DbSet<Tabitem> Tabitems { get; set; }
        public virtual DbSet<Tabsodata> Tabsodatas { get; set; }
        public virtual DbSet<Tabsorder> Tabsorders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=CustomerItemConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tabcust>(entity =>
            {
                entity.HasKey(e => e.Custid);

                entity.ToTable("TABCUST");

                entity.Property(e => e.Custid)
                    .HasColumnName("CUSTID")
                    .HasColumnType("numeric(3, 0)");

                entity.Property(e => e.Custname)
                    .IsRequired()
                    .HasColumnName("CUSTNAME")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Tabitem>(entity =>
            {
                entity.HasKey(e => e.Itemid);

                entity.ToTable("TABITEM");

                entity.Property(e => e.Itemid)
                    .HasColumnName("ITEMID")
                    .HasColumnType("numeric(3, 0)");

                entity.Property(e => e.Itemname)
                    .IsRequired()
                    .HasColumnName("ITEMNAME")
                    .HasMaxLength(20);

                entity.Property(e => e.Itemrate)
                    .HasColumnName("ITEMRATE")
                    .HasColumnType("numeric(10, 2)");
            });

            modelBuilder.Entity<Tabsodata>(entity =>
            {
                entity.HasKey(e => e.Sodataid);

                entity.ToTable("TABSODATA");

                entity.Property(e => e.Sodataid)
                    .HasColumnName("SODATAID")
                    .HasColumnType("numeric(3, 0)");

                entity.Property(e => e.Dataexst)
                    .IsRequired()
                    .HasColumnName("DATAEXST")
                    .HasMaxLength(3);

                entity.Property(e => e.Itemid)
                    .HasColumnName("ITEMID")
                    .HasColumnType("numeric(3, 0)");

                entity.Property(e => e.Itemrate)
                    .HasColumnName("ITEMRATE")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Sordid)
                    .HasColumnName("SORDID")
                    .HasColumnType("numeric(3, 0)");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Tabsodatas)
                    .HasForeignKey(d => d.Itemid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TABSODATA_fk1");

                entity.HasOne(d => d.Sord)
                    .WithMany(p => p.Tabsodatas)
                    .HasForeignKey(d => d.Sordid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TABSODATA_fk0");
            });

            modelBuilder.Entity<Tabsorder>(entity =>
            {
                entity.HasKey(e => e.Sordid);

                entity.ToTable("TABSORDER");

                entity.Property(e => e.Sordid)
                    .HasColumnName("SORDID")
                    .HasColumnType("numeric(3, 0)");

                entity.Property(e => e.Custid)
                    .HasColumnName("CUSTID")
                    .HasColumnType("numeric(3, 0)");

                entity.Property(e => e.Dataexst)
                    .IsRequired()
                    .HasColumnName("DATAEXST")
                    .HasMaxLength(3);

                entity.Property(e => e.Sordamnt)
                    .HasColumnName("SORDAMNT")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Sorddate)
                    .HasColumnName("SORDDATE")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.Tabsorders)
                    .HasForeignKey(d => d.Custid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TABSORDER_fk0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
