using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WeatherRecordServer.Models
{
    public partial class WeatherRecordDBContext : DbContext
    {
        public WeatherRecordDBContext()
        {
        }

        public WeatherRecordDBContext(DbContextOptions<WeatherRecordDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<WeatherRecords> WeatherRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=192.168.1.25;Database=WeatherRecordDB;Initial Catalog=WeatherRecordDB;User ID=bellyful_dev;Password=Password1!;Connect Timeout=30;Encrypt=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
