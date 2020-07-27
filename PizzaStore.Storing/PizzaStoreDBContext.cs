using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaStore.Storing
{
    public partial class PizzaStoreDBContext : DbContext
    {
        public PizzaStoreDBContext()
        {
        }

        public PizzaStoreDBContext(DbContextOptions<PizzaStoreDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaOrder> PizzaOrder { get; set; }
        public virtual DbSet<StoreOrders> StoreOrders { get; set; }
        public virtual DbSet<Stores> Stores { get; set; }
        public virtual DbSet<Topping> Topping { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=localhost;database=PizzaStoreDB;user id=sa;password=Password1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Orders__C3905BCF5A0F1CDF");

                entity.ToTable("Orders", "Orders");

                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.PurchaseDate).HasColumnType("datetime2(0)");

                entity.Property(e => e.TotalPrice).HasColumnType("money");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__UserId__3D5E1FD2");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.ToTable("Pizza", "Pizza");

                entity.Property(e => e.PizzaId).ValueGeneratedNever();

                entity.Property(e => e.PizzaName).HasMaxLength(250);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Size).HasMaxLength(250);
            });

            modelBuilder.Entity<PizzaOrder>(entity =>
            {
                entity.ToTable("PizzaOrder", "Orders");

                entity.Property(e => e.PizzaOrderId).ValueGeneratedNever();

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.PizzaOrder)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PizzaOrde__Order__4222D4EF");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.PizzaOrder)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PizzaOrde__Pizza__412EB0B6");
            });

            modelBuilder.Entity<StoreOrders>(entity =>
            {
                entity.ToTable("StoreOrders", "Stores");

                entity.Property(e => e.StoreOrdersId).ValueGeneratedNever();

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.StoreOrders)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StoreOrde__Order__4AB81AF0");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoreOrders)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StoreOrde__Store__49C3F6B7");
            });

            modelBuilder.Entity<Stores>(entity =>
            {
                entity.HasKey(e => e.StoreId)
                    .HasName("PK__Stores__3B82F101DC8BCE1F");

                entity.ToTable("Stores", "Stores");

                entity.Property(e => e.StoreId).ValueGeneratedNever();

                entity.Property(e => e.StoreAddress).HasMaxLength(500);

                entity.Property(e => e.StoreName).HasMaxLength(250);
            });

            modelBuilder.Entity<Topping>(entity =>
            {
                entity.ToTable("Topping", "Pizza");

                entity.Property(e => e.ToppingId).ValueGeneratedNever();

                entity.Property(e => e.ToppingName).HasMaxLength(250);

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.Topping)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Topping__PizzaId__38996AB5");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__1788CC4C2689DE29");

                entity.ToTable("Users", "Users");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.FirstName).HasMaxLength(250);

                entity.Property(e => e.LastName).HasMaxLength(250);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
