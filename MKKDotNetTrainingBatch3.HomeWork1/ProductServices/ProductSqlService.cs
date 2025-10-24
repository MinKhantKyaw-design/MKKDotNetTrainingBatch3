using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Data.SqlClient;

namespace MKKDotNetTrainingBatch3.HomeWork1.ProductServices
{
    public class ProductSqlService
    {
        SqlConnectionStringBuilder sqlConnectionBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "MKKBatch3MiniPOS",
            UserID = "sa",
            Password = "P@ssw0rd",
            TrustServerCertificate = true
        };

        public string baseQuery;

        public void Read()
        {
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionBuilder.ConnectionString);

            baseQuery = @"SELECT [ProductID]
                          ,[ProductName]
                          ,[Price]
                          ,[Quantity]    
                      FROM [dbo].[Tbl_Products] where DeleteFlag=0";

            sqlConnection.Open();

            SqlCommand sqlCommad = new SqlCommand(baseQuery, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommad);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            sqlConnection.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                int rowNo = i + 1;
                decimal price = Convert.ToDecimal(row["Price"]);
                Console.WriteLine(rowNo.ToString() + ". " + row["ProductName"] + " (" + price.ToString("n0") + ")," + " Count:" + row["Quantity"]);
            }
        }

        public void Create()
        {
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

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionBuilder.ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(baseQuery, sqlConnection);
            int result = cmd.ExecuteNonQuery();
            sqlConnection.Close();

            string message = result > 0 ? "Insert success" : "Insert failed";

            Console.WriteLine(result.ToString() + " row(s) affected");
            Console.WriteLine(message);
        }

        public void Update()
        {
            baseQuery = @"UPDATE [dbo].[Tbl_Products]
                            SET [ProductName] = 'Test2'
                            ,[Quantity] = 20
                            ,[Price] = 2000
                            ,[ModifiedDateTime] = CURRENT_TIMESTAMP
                         WHERE ProductId = 17;";
            SqlConnection connection = new SqlConnection(sqlConnectionBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(baseQuery, connection);
            int result = cmd.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            Console.WriteLine(result.ToString() + " row(s) affected");
            Console.WriteLine(message);
        }

        public void Delete()
        {
            baseQuery = @"UPDATE [dbo].[Tbl_Products]
                            SET [DeleteFlag] = 0
                            ,[ModifiedDateTime] = CURRENT_TIMESTAMP
                         WHERE ProductId = 17;";
            SqlConnection connection = new SqlConnection(sqlConnectionBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(baseQuery, connection);
            int result = cmd.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            Console.WriteLine(result.ToString() + " row(s) affected");
            Console.WriteLine(message);
        }
    }
}

