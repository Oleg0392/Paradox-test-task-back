using WebServerExample.Models;
using Microsoft.EntityFrameworkCore;

namespace WebServerExample.Data
{
    public class NoteContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>().ToTable("Notes");
            modelBuilder.Entity<Tag>().ToTable("Tag");
        }
    }
}
