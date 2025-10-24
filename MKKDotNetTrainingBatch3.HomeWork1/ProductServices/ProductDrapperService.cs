using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKKDotNetTrainingBatch3.HomeWork1.ProductServices
{
    public class ProductDrapperService
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
            List<ProductDTO> lst;
            using (IDbConnection connection=new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                baseQuery = @"SELECT [ProductID]
                          ,[ProductName]
                          ,[Price]
                          ,[Quantity]    
                      FROM [dbo].[Tbl_Products] where DeleteFlag=0";

                connection.Open();

                lst = connection.Query<ProductDTO>(baseQuery).ToList();
            }

            for(int i=0; i< lst.Count(); i++)
            {
                ProductDTO item = lst[i];
                Console.WriteLine($"{i+1}. {item.ProductName} ({item.Price:n0}) Count: {item.Quantity}");
            }
        }

        public void Create()
        {
            int result = 0;
            using (IDbConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                connection.Open();
                baseQuery = @"INSERT INTO [dbo].[Tbl_Products]
                                   ([ProductName]
                                   ,[Quantity]
                                   ,[Price]
                                   ,[DeleteFlag]
                                   ,[CreatedDateTime])
                             VALUES
                                   ('Test'
                                   ,10
                                   ,10000
                                   ,0
                                   ,CURRENT_TIMESTAMP);";

                result = connection.Execute(baseQuery);
            }
            string message = result > 0 ? "Insert success" : "Insert failed";

            Console.WriteLine(result.ToString() + " row(s) affected");
            Console.WriteLine(message);
        }

        public void Update()
        {
            int result = 0;
            using (IDbConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                connection.Open();
                baseQuery = @"UPDATE [dbo].[Tbl_Products]
                            SET [ProductName] = 'Test2'
                            ,[Quantity] = 20
                            ,[Price] = 2000
                            ,[ModifiedDateTime] = CURRENT_TIMESTAMP
                         WHERE ProductId = 20;";
                result = connection.Execute(baseQuery);
            }
            string message = result > 0 ? "Update success" : "Update failed";

            Console.WriteLine(result.ToString() + " row(s) affected");
            Console.WriteLine(message);
        }

        public void Delete()
        {
            int result = 0;
            using (IDbConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                connection.Open();
                baseQuery = @"UPDATE [dbo].[Tbl_Products]
                            SET [DeleteFlag] = 1
                            ,[ModifiedDateTime] = CURRENT_TIMESTAMP
                         WHERE ProductId = 20;";
                result = connection.Execute(baseQuery);
            }
            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            Console.WriteLine(result.ToString() + " row(s) affected");
            Console.WriteLine(message);
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
    }
}
