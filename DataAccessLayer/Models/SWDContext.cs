using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccessLayer.Models
{
    public partial class SWDContext : DbContext
    {
        public SWDContext()
        {
        }

        public SWDContext(DbContextOptions<SWDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<DiscountPr> DiscountPrs { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<ImportBill> ImportBills { get; set; } = null!;
        public virtual DbSet<ImportBillDetail> ImportBillDetails { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductInfo> ProductInfos { get; set; } = null!;
        public virtual DbSet<ReceivingAddress> ReceivingAddresses { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Style> Styles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=MSI\\SQLEXPRESS;database=SWD;user=sa;password=123;TrustServerCertificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DiscountPr>(entity =>
            {
                entity.ToTable("DiscountPr");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasMany(d => d.ProductInfos)
                    .WithMany(p => p.Discounts)
                    .UsingEntity<Dictionary<string, object>>(
                        "DiscountProductInfo",
                        l => l.HasOne<ProductInfo>().WithMany().HasForeignKey("ProductInfoId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__DiscountP__Produ__5812160E"),
                        r => r.HasOne<DiscountPr>().WithMany().HasForeignKey("DiscountId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__DiscountP__Disco__571DF1D5"),
                        j =>
                        {
                            j.HasKey("DiscountId", "ProductInfoId").HasName("PK__Discount__93A09325698C3CAA");

                            j.ToTable("DiscountProductInfo");
                        });
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.Link)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.ProductInfo)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.ProductInfoId)
                    .HasConstraintName("FK__Images__ProductI__5AEE82B9");
            });

            modelBuilder.Entity<ImportBill>(entity =>
            {
                entity.ToTable("ImportBill");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.TotalMoney).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ImportBills)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ImportBil__UserI__693CA210");
            });

            modelBuilder.Entity<ImportBillDetail>(entity =>
            {
                entity.Property(e => e.ExpiredDate).HasColumnType("date");

                entity.Property(e => e.ImportPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.ImportBill)
                    .WithMany(p => p.ImportBillDetails)
                    .HasForeignKey(d => d.ImportBillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ImportBil__Impor__6C190EBB");

                entity.HasOne(d => d.ProductInfo)
                    .WithMany(p => p.ImportBillDetails)
                    .HasForeignKey(d => d.ProductInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ImportBil__Produ__6D0D32F4");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Note)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalMoney).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Orders__Customer__7A672E12");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .HasConstraintName("FK__Orders__PaymentM__7C4F7684");

                entity.HasOne(d => d.ReceivingAddress)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ReceivingAddressId)
                    .HasConstraintName("FK__Orders__Receivin__7B5B524B");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderDeta__Order__00200768");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__OrderDeta__Produ__7F2BE32F");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.ToTable("PaymentMethod");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PaymentMethods)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__PaymentMe__UserI__778AC167");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Size)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductInfo>(entity =>
            {
                entity.ToTable("ProductInfo");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.MainImage)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductInfos)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__ProductIn__Produ__6FE99F9F");
            });

            modelBuilder.Entity<ReceivingAddress>(entity =>
            {
                entity.ToTable("ReceivingAddress");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ReceivingAddresses)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Receiving__Custo__74AE54BC");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Style>(entity =>
            {
                entity.ToTable("Style");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasMany(d => d.Categories)
                    .WithMany(p => p.Styles)
                    .UsingEntity<Dictionary<string, object>>(
                        "StyleCategory",
                        l => l.HasOne<Category>().WithMany().HasForeignKey("CategoryId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__StyleCate__Categ__66603565"),
                        r => r.HasOne<Style>().WithMany().HasForeignKey("StyleId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__StyleCate__Style__656C112C"),
                        j =>
                        {
                            j.HasKey("StyleId", "CategoryId").HasName("PK__StyleCat__2B41D5E027AD4D32");

                            j.ToTable("StyleCategory");
                        });

                entity.HasMany(d => d.ProductInfos)
                    .WithMany(p => p.Styles)
                    .UsingEntity<Dictionary<string, object>>(
                        "StyleProductInfo",
                        l => l.HasOne<ProductInfo>().WithMany().HasForeignKey("ProductInfoId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__StyleProd__Produ__60A75C0F"),
                        r => r.HasOne<Style>().WithMany().HasForeignKey("StyleId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__StyleProd__Style__5FB337D6"),
                        j =>
                        {
                            j.HasKey("StyleId", "ProductInfoId").HasName("PK__StylePro__FD4EB8F3B406AFC4");

                            j.ToTable("StyleProductInfo");
                        });
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.UserName, "UQ__Users__C9F28456F0915254")
                    .IsUnique();

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PassWord)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserRole",
                        l => l.HasOne<Role>().WithMany().HasForeignKey("RoleId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserRoles__RoleI__5070F446"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserRoles__UserI__4F7CD00D"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId").HasName("PK__UserRole__AF2760AD637F830C");

                            j.ToTable("UserRoles");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
