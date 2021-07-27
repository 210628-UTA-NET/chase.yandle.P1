using Microsoft.EntityFrameworkCore;
using Models;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DL
{
    public class StDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
        public DbSet<Inventory> Inventories { get; set; }

        public StDbContext() : base()
        { }

        public StDbContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder p_modelBuilder)
        {

            p_modelBuilder.Entity<Customer>()
                .Property(cust => cust.cID)
                .ValueGeneratedOnAdd();

            p_modelBuilder.Entity<Customer>()
                .HasKey(cust => cust.cID);

            p_modelBuilder.Entity<Store>()
                .Property(sto => sto.stID)
                .ValueGeneratedOnAdd();

                p_modelBuilder.Entity<Store>()
                .HasKey(sto => sto.stID);

            p_modelBuilder.Entity<Order>()
                .Property(ord => ord.oID)
                .ValueGeneratedOnAdd();

            p_modelBuilder.Entity<Order>()
                .HasKey(ord => ord.oID);

            p_modelBuilder.Entity<Order>()
                .HasOne(ord => ord.oCustomer)
                .WithMany(cust => cust.cOrders)
                .HasForeignKey(ord => ord.oCustomerID);

            p_modelBuilder.Entity<Order>()
                .HasOne(ord => ord.oStore)
                .WithMany(store => store.stOrders)
                .HasForeignKey(ord => ord.oStoreID);


            p_modelBuilder.Entity<Product>()
                .Property(prod => prod.pID)
                .ValueGeneratedOnAdd();

            p_modelBuilder.Entity<Product>()
                .HasKey(prod => prod.pID);

            p_modelBuilder.Entity<LineItem>()
                .Property(litm => litm.liID)
                .ValueGeneratedOnAdd();

            p_modelBuilder.Entity<LineItem>()
                .HasKey(lit => lit.liID);

            p_modelBuilder.Entity<LineItem>()
                .HasOne(li => li.liOrder)
                .WithMany(ord => ord.oLineItems)
                .HasForeignKey(li => li.liOrderID);

            p_modelBuilder.Entity<LineItem>()
                .HasOne(li => li.liProduct)
                .WithMany(prod => prod.pLineItems)
                .HasForeignKey(li => li.liProductID);

            p_modelBuilder.Entity<Inventory>()
                .HasKey(inv => new {inv.iStoreID, inv.iProductID});

            p_modelBuilder.Entity<Inventory>()
                .HasOne(inv => inv.iStore)
                .WithMany(st => st.stInventory)
                .HasForeignKey(inv => inv.iStoreID);

            p_modelBuilder.Entity<Inventory>()
                .HasOne(inv => inv.iProduct)
                .WithMany(st => st.pInventory)
                .HasForeignKey(inv => inv.iProductID);
            
        }
    }
}
