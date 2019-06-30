using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using videotheque.bean;

namespace videotheque.dataAccess
{
    public class VideothequeDbContext : DbContext
    {
        private static VideothequeDbContext _context = null;
        public async static Task<VideothequeDbContext> GetCurrent()
        {
            if (_context == null)
            {
                _context = new VideothequeDbContext(
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.db"));
                await _context.Database.MigrateAsync();
            }
            return _context;
        }

        internal VideothequeDbContext(DbContextOptions options) : base(options) { }

        private VideothequeDbContext(string databasePath) : base()
        {
            DatabasePath = databasePath;
        }

        public string DatabasePath { get; }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Media> Media { get; set; }

        public DbSet<MediaGenre> MediaGenre { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            base.OnConfiguring(optionBuilder);
            optionBuilder.EnableSensitiveDataLogging();
            optionBuilder.UseSqlite($"Filename={DatabasePath}", x => x.SuppressForeignKeyEnforcement());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<bean.MediaGenre>().HasKey(ab => new { ab.IdGenre, ab.IdMedia });
        }
    }
}
