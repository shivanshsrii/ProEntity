using Microsoft.EntityFrameworkCore;

namespace ProEnity 
{

    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MyDbContext())
            {
                var purchase = new Purchase()
                {
                    Id = 1,
                    Product = "Shirts",
                    Price = 99.99m
                };
                context.Purchases.Add(purchase);
                context.SaveChanges();
                var allPurchases=context.Purchases.ToList();
                var p=context.Purchases.FirstOrDefault(p=>p.Product=="Shirts");
            }
        }
    }
    public class MyDbContext: DbContext
    {
        public DbSet<Purchase> Purchases { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseInMemoryDatabase("MYDB");
        }
    }
    public class Purchase
    {
        public int Id { get; set; }
        public string? Product { get; set; }
        public decimal Price { get; set; }
    }
}
