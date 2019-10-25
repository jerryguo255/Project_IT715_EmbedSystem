using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;
namespace TestSerial_ConsoleApp
{
    public class WeatherRecordDBContext : DbContext {
        public DbSet<WeatherRecord> WeatherRecords { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
            @"Data Source=192.168.1.25;Database=WeatherRecordDB;Initial Catalog=WeatherRecordDB;
                User ID=bellyful_dev;Password=Password1!;Connect Timeout=30;Encrypt=False;
                TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
   
        


            
         