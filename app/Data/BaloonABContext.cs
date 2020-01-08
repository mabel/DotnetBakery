using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using app.Models;

namespace app
{
    public class BaloonABContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=Data/baloon_ab.db");
    }
}
