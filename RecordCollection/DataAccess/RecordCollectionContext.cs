using Microsoft.EntityFrameworkCore;
using RecordCollection.Models;

namespace RecordCollection.DataAccess
{
    public class RecordCollectionContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public RecordCollectionContext(DbContextOptions<RecordCollectionContext> options) : base(options) { }
    }
}
