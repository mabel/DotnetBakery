using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace app.Models
{
    public class BakeryContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<FeedbackRow> FeedbackRows { get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=Data/products.db");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<FeedbackRow>(eb => {
                        eb.HasNoKey();
                        eb.ToView("feedback_rows");
            });
        }
    }
}
