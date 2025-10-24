using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MKKDotNetTrainingBatch3.HomeWork1.Database.DBFirstHWDbContextModels;

namespace MKKDotNetTrainingBatch3.HomeWork1.ProductServices
{
    public class ProductEFCoreDBService
    {
        private readonly DBFirstHWDbContext db;

        public ProductEFCoreDBService()
        {
            db = new DBFirstHWDbContext();
        }

        public void Read()
        {
            var lst = db.TblProducts.Where(x => x.DeleteFlag == false).ToList();

            for (int i = 0; i < lst.Count(); i++)
            {
                var item = lst[i];
                Console.WriteLine($"{i + 1}. {item.ProductName} ({item.Price:n0}) Count: {item.Quantity}");
            }
        }

        public void Create()
        {
            db.TblProducts.Add(new TblProduct
            {
                ProductName = "Test",
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
            var findItem = db.TblProducts.FirstOrDefault(x => x.ProductId == 23);
            if (findItem is null)
            {
                return;
            }
            findItem.ProductName = "Test2";
            findItem.Quantity = 20;
            findItem.Price = 20000;
            findItem.ModifiedDateTime = DateTime.Now;

            int result = db.SaveChanges();
            string message = result > 0 ? "Update Successful." : "Update Failed.";
            Console.WriteLine(message);
        }

        public void Delete()
        {
            var findItem = db.TblProducts.FirstOrDefault(x => x.ProductId == 23 && x.DeleteFlag == false);
            if (findItem is null)
            {
                Console.WriteLine("Delete Failed.");
                return;
            }
            findItem.DeleteFlag = true;
            findItem.ModifiedDateTime = DateTime.Now;

            int result = db.SaveChanges();
            string message = result > 0 ? "Delete Successful." : "Delete Failed.";
            Console.WriteLine(message);
        }
    }
}

