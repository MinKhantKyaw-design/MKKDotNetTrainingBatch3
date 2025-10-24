using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKKDotNetTrainingBatch3.HomeWork1.ProductServices
{
    public class ProductEFCoreModelService
    {
        private readonly ModelFirstHWDbContext db;

        public ProductEFCoreModelService()
        {
            db = new ModelFirstHWDbContext();
        }

        public void Read()
        {
            var lst = db.Tbl_Products.Where(x => x.DeleteFlag == false).ToList();

            for (int i = 0; i < lst.Count(); i++)
            {
                var item = lst[i];
                Console.WriteLine($"{i + 1}. {item.ProductName} ({item.Price:n0}) Count: {item.Quantity}");
            }
        }

        public void Create() 
        {
            db.Tbl_Products.Add(new Tbl_Products
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
            var findItem = db.Tbl_Products.FirstOrDefault(x=> x.ProductID == 21);
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

        public void Delete1()
        {
            var findItem = db.Tbl_Products.FirstOrDefault(x => x.ProductID == 21 && x.DeleteFlag == false);
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

        public void Delete2()
        {
            var findItem = db.Tbl_Products.FirstOrDefault(x => x.ProductID == 22);
            if (findItem is null)
            {
                Console.WriteLine("Category not found.");
                return;
            }
            db.Tbl_Products.Remove(findItem);

            int result = db.SaveChanges();
            string message = result > 0 ? "Delete Successful." : "Delete Failed.";
            Console.WriteLine(message);
        }
    }
}
