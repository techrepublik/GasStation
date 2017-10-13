namespace GasStation.dal.data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GasModel : DbContext
    {
        public GasModel()
            : base("name=GasModel")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<FuelType> FuelTypes { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<UserLevel> UserLevels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.CustomerName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CustomerPlateNo)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CustomerVehicle)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Transactions)
                .WithOptional(e => e.Customer)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeeName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeeSex)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeeAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Transactions)
                .WithOptional(e => e.Employee)
                .WillCascadeOnDelete();

            modelBuilder.Entity<FuelType>()
                .Property(e => e.FuelTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<FuelType>()
                .HasMany(e => e.Transactions)
                .WithOptional(e => e.FuelType)
                .WillCascadeOnDelete();

            modelBuilder.Entity<UserLevel>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<UserLevel>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<UserLevel>()
                .HasMany(e => e.Transactions)
                .WithOptional(e => e.UserLevel)
                .WillCascadeOnDelete();
        }
    }
}
