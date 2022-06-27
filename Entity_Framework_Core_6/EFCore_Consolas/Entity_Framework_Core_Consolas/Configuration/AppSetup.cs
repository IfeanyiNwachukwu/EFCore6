using Entity_Framework_Core_Db_Library.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Entity_Framework_Core_Consolas.Configuration
{
    public static class AppSetup
    {
         private static IConfigurationRoot _configuration;
         public static DbContextOptionsBuilder<InventoryDbContext> _optionsBuilder;

        public static void BuildOptions()
        {
            _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
           _optionsBuilder = new DbContextOptionsBuilder<InventoryDbContext>();
           _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("InventoryManager"));
        }

        public static void DisplayConnectionString()
        {
            Console.WriteLine($"CNSTR: {_configuration.GetConnectionString("AdventureWorks")}");
        }
    }
}
