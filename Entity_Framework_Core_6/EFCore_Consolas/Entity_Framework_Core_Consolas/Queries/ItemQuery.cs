using Entity_Framework_Core_Consolas.Configuration;
using Entity_Framework_Core_Db_Library.DbContexts;
using InventoryModels.Models;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework_Core_Consolas.Queries
{
    public static class ItemQuery
    {
        public static DbContextOptionsBuilder<InventoryDbContext> _optionsBuilder = AppSetup._optionsBuilder;
        private static void EnsureItem(string name)
        {
            using (var db = new InventoryDbContext(_optionsBuilder.Options))
            {
                // determine if item exists:
                var existingItem = db.Items.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());

                if (existingItem == null)
                {
                    // doesn't exist, add it
                    var item = new Item() { Name = name };
                    db.Items.Add(item);
                    db.SaveChanges();
                }
            }
        }

        public static void EnsureItems()
        {
            EnsureItem("Batmn Begins");
            EnsureItem("Inception");
            EnsureItem("Remember the Titans");
            EnsureItem("Star Wars: The Empire Strikes Back");
            EnsureItem("TopGun");
        }

        public static void ListIventory()
        {
            using(var db = new InventoryDbContext(_optionsBuilder.Options))
            {
                var items = db.Items.OrderBy(x => x.Name).ToList();
                items.ForEach(x => Console.WriteLine($"New Item {x.Name}"));
            }
        }
        
    }
}
