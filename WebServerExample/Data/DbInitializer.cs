﻿using WebServerExample.Models;
using System.Linq;
using System;

namespace WebServerExample.Data
{
    public static class DbInitializer
    {
        public static void Initialize(NoteContext context)
        {
            context.Database.EnsureCreated();

            if (context.Notes.Any())
            {
                return;   // DB has been seeded
            }

            var notes = new Note[]     // test data
            {
                new Note{NoteID=0,Name="работа",Raw="сделать отчеты"},
                new Note{NoteID=1,Name="дом",Raw="помочь приготовить ужин"},
                new Note{NoteID=2,Name="магазин",Raw="не забыть порошок"},
                new Note{NoteID=3,Name="машина",Raw="оплатить страховку"}
            };
            foreach (Note note in notes)
            {
                context.Notes.Add(note);
            }
            context.SaveChanges();

            var tags = new Tag[]
            {
                new Tag{TagID=0,Title="срочное"},
                new Tag{TagID=1,Title="НЕзабыть"}
            };
            foreach (Tag tag in tags)
            {
                context.Tags.Add(tag);
            }
            context.SaveChanges();
        }
    }
}