using Microsoft.EntityFrameworkCore;
using Task.Models.db;

namespace Task.Models
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Item_Order> Item_Orders { get; set; }
    }
}