using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace gunn
{
    public class DboContext : DbContext
    {
        private string _filePath;

        public DboContext(string filePath)
        {
            _filePath = filePath;
        }

        public DbSet<Guns> Guns { get; set; }
        public DbSet<Ammos> Ammos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_filePath}");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
