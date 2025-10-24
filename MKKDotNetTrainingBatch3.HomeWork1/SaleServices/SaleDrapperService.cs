using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;
using Microsoft.Data.SqlClient;

namespace MKKDotNetTrainingBatch3.HomeWork1.SaleServices
{
    public class SaleDrapperService
    {
        string baseQuery;

        SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "MKKBatch3MiniPOS",
            UserID = "sa",
            Password = "P@ssw0rd",
            TrustServerCertificate = true
        };

        public void Read()
        {
            List<SaleDTO> lst;
            using (IDbConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                baseQuery = @"SELECT [SaleId]
                              ,[ProductId]
                              ,[Quantity]
                              ,[Price]
                              ,[DeleteFlag]
                              ,[CreatedDateTime]
                          FROM [dbo].[Tbl_Sales]
                          WHERE DeleteFlag = 0";

                connection.Open();

                lst = connection.Query<SaleDTO>(baseQuery).ToList();
            }

            Console.WriteLine("Sale Lists");
            for (int i = 0; i < lst.Count(); i++)
            {
                SaleDTO item = lst[i];
                Console.WriteLine($"{i + 1}. ProductId: {item.ProductId} ({item.Price:n0}) Count: {item.Quantity}");
            }
        }

        public void Create()
        {
            string checkProductQuery = @"SELECT [ProductId], [Quantity] FROM [dbo].[Tbl_Products] WHERE ProductID = 12 AND DeleteFlag = 0";

            baseQuery = @"INSERT INTO [dbo].[Tbl_Sales]
                               ([ProductId]
                               ,[Quantity]
                               ,[Price]
                               ,[DeleteFlag]
                               ,[CreatedDateTime])
                         VALUES
                               (12
                               ,1
                               ,800
                               ,0
                               ,CURRENT_TIMESTAMP);";

            string updateProductQuery = @"UPDATE [dbo].[Tbl_Products]
                                           SET [Quantity] = Quantity - 1
                                              ,[ModifiedDateTime] = CURRENT_TIMESTAMP
                                         WHERE ProductID = 12";

            using (IDbConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                connection.Open();

                ProductDTO checkResult = connection.Query<ProductDTO>(checkProductQuery).FirstOrDefault();
                var productId = checkResult?.ProductID;

                if (productId == null)
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
                    int insertSaleResult = connection.Execute(baseQuery);
                    if (insertSaleResult > 0)
                    {
                        // Update Product into Tbl_Products
                        int updateProductResult = connection.Execute(updateProductQuery);
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

        public class ProductDTO()
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
            public bool DeleteFlag { get; set; }
            public DateTime CreatedDateTime { get; set; }
            public DateTime? ModifiedDateTime { get; set; }
        }

        public class SaleDTO()
        {
            public int SaleId { get; set; }
            public int ProductId { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
            public bool DeleteFlag { get; set; }
            public DateTime CreatedDateTime { get; set; }
        }
    }
}
