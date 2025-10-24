using MKKDotNetTrainingBatch3.HomeWork1.Database.DBFirstHWDbContextModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKKDotNetTrainingBatch3.HomeWork1.SaleServices
{
    public class SaleEFCoreDBService
    {
        private readonly DBFirstHWDbContext db;

        public SaleEFCoreDBService()
        {
            db = new DBFirstHWDbContext();
        }

        public void Read()
        {
            var lst = db.TblSales.Where(x => x.DeleteFlag == false).ToList();

            Console.WriteLine("Sale Lists");
            for (int i = 0; i < lst.Count(); i++)
            {
                var item = lst[i];
                Console.WriteLine($"{i + 1}. ProductId: {item.ProductId} ({item.Price:n0}) Count: {item.Quantity}");
            }
        }

        public void Create()
        {
            var checkResult = db.TblProducts.Where(x => x.ProductId == 12 & x.DeleteFlag == false).FirstOrDefault();

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

                db.TblSales.Add(new TblSale
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
