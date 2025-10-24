using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MKKDotNetTrainingBatch3.HomeWork1.SaleServices
{
    public class SaleEFCoreModelService
    {
        private readonly ModelFirstHWDbContext db;

        public SaleEFCoreModelService()
        {
            db = new ModelFirstHWDbContext();
        }

        public void Read()
        {
            var lst = db.Tbl_Sales.Where(x => x.DeleteFlag == false).ToList();

            Console.WriteLine("Sale Lists");
            for (int i = 0; i < lst.Count(); i++)
            {
                var item = lst[i];
                Console.WriteLine($"{i + 1}. ProductId: {item.ProductId} ({item.Price:n0}) Count: {item.Quantity}");
            }
        }

        public void Create()
        {
            var checkResult = db.Tbl_Products.Where(x => x.ProductID == 12 & x.DeleteFlag == false).FirstOrDefault();

            if (checkResult is null)
            {
                Console.WriteLine("Product Not Found.");
            }
            else
            {
                int quantity = Convert.ToInt32(checkResult.Quantity);

                if (quantity <= 0)
                {
                    Console.WriteLine("Insufficient Product's Quantity.");
                    return;
                }

                // Insert Sale into Tbl_Sales

                db.Tbl_Sales.Add(new Tbl_Sales
                {
                    ProductId = 12,
                    Quantity = 1,
                    Price = 900,
                    DeleteFlag = false,
                    CreatedDateTime = DateTime.Now
                });
                int insertSaleResult = db.SaveChanges();

                if (insertSaleResult > 0)
                {
                    // Update Product into Tbl_Products

                    checkResult.Quantity = checkResult.Quantity - 1;
                    checkResult.ModifiedDateTime = DateTime.Now;
                    int updateProductResult = db.SaveChanges();

                    string updateResultMSG = updateProductResult > 0 ? "Sale Inserted and Products Updated Successfully." : "Sale Inserted but Products Update Failed.";
                    Console.WriteLine(updateResultMSG);
                }
                else
                {
                    Console.WriteLine("Sale Insert Failed.");
                }

            }
        }
    }
}
