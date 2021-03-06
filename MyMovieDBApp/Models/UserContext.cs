using Microsoft.EntityFrameworkCore;

namespace MyMovieDBApp.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<SearchHistory> SearchHistory { get; set; }
    }
}
