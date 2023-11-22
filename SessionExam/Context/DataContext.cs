using Microsoft.EntityFrameworkCore;
using SessionExam.Models;

namespace SessionExam.Context
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){ 
            
        }

        public DbSet<User> Users { get; set; }


    }
}
