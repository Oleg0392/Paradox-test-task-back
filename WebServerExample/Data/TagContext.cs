using WebServerExample.Models;
using Microsoft.EntityFrameworkCore;

namespace WebServerExample.Data
{

    public class TagContext : DbContext
    {
        public TagContext(DbContextOptions<TagContext> options) : base(options) { }

        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>().ToTable("Tag");
        }
    }
}
