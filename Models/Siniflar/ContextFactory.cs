using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace TatilSeyahatProjesiCore.Models.Siniflar
{
    public class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory();

            // Bu satırı ekle: appsettings.json orada mı kontrol et
            var configPath = Path.Combine(basePath, "appsettings.json");
            if (!File.Exists(configPath))
                throw new FileNotFoundException("appsettings.json bulunamadı: " + configPath);

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new Context(optionsBuilder.Options);
        }
    }
}
