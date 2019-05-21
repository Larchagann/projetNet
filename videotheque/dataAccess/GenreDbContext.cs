using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using videotheque.bean;

namespace videotheque.dataAccess
{
    public class GenreDbContext : DbContext
    {
        private static GenreDbContext _context = null;
        public async static Task<GenreDbContext> GetCurrent()
        {
            if (_context == null)
            {
                _context = new GenreDbContext(
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.db"));
                await _context.Database.MigrateAsync();
            }
            return _context;
        }

        internal GenreDbContext(DbContextOptions options) : base(options) { }
        private GenreDbContext(string databasePath) : base()
        {
            DatabasePath = databasePath;
        }

        public string DatabasePath { get; }

        public DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            base.OnConfiguring(optionBuilder);
            optionBuilder.EnableSensitiveDataLogging();
            optionBuilder.UseSqlite($"Filename={DatabasePath}", x => x.SuppressForeignKeyEnforcement());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
