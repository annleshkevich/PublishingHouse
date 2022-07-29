using Microsoft.EntityFrameworkCore;
using Publishing_House.Model.DatabaseModels;

namespace Publishing_House.Model
{
    public class PublishingHouseContext : DbContext
    {
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<PublishingHouse> PublishingHouses { get; set; } = null!;
        public PublishingHouseContext(DbContextOptions<PublishingHouseContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
