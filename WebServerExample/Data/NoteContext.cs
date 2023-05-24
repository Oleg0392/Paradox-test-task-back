﻿using WebServerExample.Models;
using Microsoft.EntityFrameworkCore;

namespace WebServerExample.Data
{
    public class NoteContext : DbContext
    {
        public NoteContext(DbContextOptions<NoteContext> options) : base(options) { }
        
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>().ToTable("Notes");
        }
    }

}
