using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;
using Microsoft.Data.SqlClient;

namespace MKKDotNetTrainingBatch3.ConsoleApp1
{
    public class ProductDapperService
    {
        SqlConnectionStringBuilder sqlConnectionStringBuilder = new()
        {
            DataSource = ".",
            InitialCatalog = "MKKBatch3MiniPOS",
            UserID = "sa",
            Password = "P@ssw0rd",
            TrustServerCertificate = true
        };

        string baseQuery;
        public void Read()
        {
            List<ProductDTO> lst;
            using (IDbConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                connection.Open();
                baseQuery = @"SELECT [ProductID]
                          ,[ProductName]
                          ,[Price]
                          ,[DeleteFlag]
                      FROM [dbo].[Tbl_Products] where DeleteFlag=0";

                lst = connection.Query<ProductDTO>(baseQuery).ToList();
            }
            foreach (ProductDTO item in lst)
            {
                Console.WriteLine($"{item.ProductID}. {item.ProductName} ({item.Price:n0})");
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
               ,[DeleteFlag])
         VALUES
               ('Test'
               ,10
               ,10000
               ,0);";

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
                          WHERE ProductName = 'Test2';";
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
                baseQuery = @"Delete From Products WHERE ProductName = 'Test2';";
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
        }
    }
}
