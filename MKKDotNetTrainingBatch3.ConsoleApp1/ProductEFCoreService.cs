using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MKKDotNetTrainingBatch3.ConsoleApp1.ProductDapperService;

namespace MKKDotNetTrainingBatch3.ConsoleApp1
{
    public class ProductEFCoreService
    {
        private readonly ModelFirstAppDbContext db;
        public ProductEFCoreService()
        {
            db = new ModelFirstAppDbContext();
        }

        public void Read()
        {
            //or
            // ModelFirstAppDbContext db = new ModelFirstAppDbContext();
            var lst = db.Products.Where(x => x.DeleteFlag == false).ToList();

            foreach (var item in lst)
            {
                Console.WriteLine($"{item.ProductId}. {item.ProductName} ({item.Price:n0})");
            }
        }

        public void Create()
        {
            db.Products.Add(new Tbl_Product
            {
                ProductName = "Test EF Core Product",
                Quantity = 10,
                Price = 10000,
                DeleteFlag = false,
                CreatedDateTime = DateTime.Now
            });

            int result = db.SaveChanges();
            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            Console.WriteLine(message);
        }

        public void Update()
        {
            var findItem = db.Products.FirstOrDefault(x => x.ProductId == 8);
            //var item = db.Products.Where(x => x.ProductId == 9).FirstOrDefault();

            if (findItem is null) 
            {
                return;
            }

            findItem.Price = 15000;
            findItem.ModifiedDateTime = DateTime.Now;

            int result = db.SaveChanges(); // if item exist update, else add new data row
            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            Console.WriteLine(message);
        }

        public void Delete()
        {
            var findItem = db.Products.FirstOrDefault(x => x.ProductId == 8);

            if (findItem is null)
            {
                return;
            }

            // var result = db.Products.Remove(findItem);

            findItem.DeleteFlag = true;
            int result = db.SaveChanges();
            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            Console.WriteLine(message);
        }
    }
}
