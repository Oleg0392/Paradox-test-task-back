using WebServerExample.Models;
using System.Linq;
using System;

namespace WebServerExample.Data
{
    public class DbTagInitializer
    {
        public static void Initialize(TagContext context)
        {
            context.Database.EnsureCreated();

            if (context.Tags.Any())
            {
                return;
            }

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
