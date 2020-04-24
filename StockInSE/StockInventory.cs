namespace StockInSE
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;

    public class StockInventory : DbContext
    {
        // Your context has been configured to use a 'InventoryContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'StockInSE.InventoryContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'InventoryContext' 
        // connection string in the application configuration file.
        public StockInventory()
            : base("name=StockInventory")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StockInventory, Migrations.Configuration>());
            this.Configuration.LazyLoadingEnabled = false;
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<Category> Categories { get; set; }
         public virtual DbSet<Product> Products { get; set; }
         public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<StockTransaction> StockTransactions { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}