using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Model
{
    public class MainDBContext:DbContext
    {
        public DbSet<Food> Foods { get; set; }
        public DbSet<GoalDefinition> GoalDefinitions { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserDislike> UserDislikes{ get; set; }

        public DbSet<UserInfo> UserInfos{ get; set; }

        public DbSet<UserMenuItem> UserMenuItems{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-7KSJ5NF\SQLEXPRESS;Initial Catalog=AlphaBodyDB;Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDislike>().HasKey(e => new { e.UserId, e.FoodId }); 
        }
    }
}
