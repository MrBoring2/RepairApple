using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace AppleRepair.Data
{
    public partial class AppleRepairContext : DbContext
    {
        public AppleRepairContext()
            : base("name=AppleRepairContextHome")
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Delivery> Delivery { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<MaterialInDelivery> MaterialInDelivery { get; set; }
        public virtual DbSet<MaterialToOrder> MaterialToOrder { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<PhoneModel> PhoneModel { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Delivery>()
                .Property(e => e.Date)
                .IsUnicode(false);

            modelBuilder.Entity<Delivery>()
                .HasMany(e => e.MaterialInDelivery)
                .WithRequired(e => e.Delivery)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Material>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Material>()
                .HasMany(e => e.MaterialInDelivery)
                .WithRequired(e => e.Material)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Material>()
                .HasMany(e => e.MaterialToOrder)
                .WithRequired(e => e.Material)
                .HasForeignKey(e => e.OrderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Material>()
                .HasMany(e => e.PhoneModel)
                .WithMany(e => e.Material)
                .Map(m => m.ToTable("AvailableMaterialsForModel").MapLeftKey("MaterialId").MapRightKey("ModelId"));

            modelBuilder.Entity<Order>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Decription)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.MaterialToOrder)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Service)
                .WithMany(e => e.Order)
                .Map(m => m.ToTable("ServiceToOrder").MapLeftKey("OrderId").MapRightKey("ServiceId"));

            modelBuilder.Entity<PhoneModel>()
                .Property(e => e.ModelName)
                .IsUnicode(false);

            modelBuilder.Entity<PhoneModel>()
                .Property(e => e.Color)
                .IsUnicode(false);

            modelBuilder.Entity<PhoneModel>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.PhoneModel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Employee)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Service>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Delivery)
                .WithRequired(e => e.Supplier)
                .WillCascadeOnDelete(false);
        }
    }
}
