using Microsoft.EntityFrameworkCore;
using SearchifyAPI.Models;

namespace SearchifyAPI.Data
{
    public class AppDbContext : DbContext
    {
        //Using Code First Method
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { } // DB Creation 

        public virtual DbSet<SearchResult> SearchResults { get; set; } //Table Creation
    }
}
