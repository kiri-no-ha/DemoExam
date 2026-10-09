using DemoExam.Scripts.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows.Controls;
using DemoExam.Scripts.Models;

namespace DemoExam.Scripts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Role> roles { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Manufacturer> manufacturers { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<StockItem> stock_items { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> order_items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source=db.db").UseLazyLoadingProxies();
        }
    }
}