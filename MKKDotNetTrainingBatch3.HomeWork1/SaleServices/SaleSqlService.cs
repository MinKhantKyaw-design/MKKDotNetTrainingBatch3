using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKKDotNetTrainingBatch3.HomeWork1.SaleServices
{
    public class SaleSqlService
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

            baseQuery = @"SELECT [SaleId]
                              ,[ProductId]
                              ,[Quantity]
                              ,[Price]
                              ,[DeleteFlag]
                              ,[CreatedDateTime]
                          FROM [dbo].[Tbl_Sales]
                          WHERE DeleteFlag = 0";

            sqlConnection.Open();

            SqlCommand sqlCommad = new SqlCommand(baseQuery, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommad);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            sqlConnection.Close();

            Console.WriteLine("Sale Lists");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                int rowNo = i + 1;
                decimal price = Convert.ToDecimal(row["Price"]);
                Console.WriteLine(rowNo.ToString() + ". ProductID:" + row["ProductId"] + " (" + price.ToString("n0") + ")," + " Count:" + row["Quantity"]);
            }
        }

        public void Create()
        {
            string checkProductQuery = @"SELECT [Quantity] FROM [dbo].[Tbl_Products] WHERE ProductID = 12 AND DeleteFlag = 0";

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

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionBuilder.ConnectionString);
            sqlConnection.Open();

            SqlCommand checkProductCMD = new SqlCommand(checkProductQuery, sqlConnection);

            object checkResult = checkProductCMD.ExecuteScalar();

            if (checkResult == null || checkResult == DBNull.Value)
            {
                Console.WriteLine("Product Not Found.");
            }
            else
            {
                int quantity = Convert.ToInt32(checkResult);

                if(quantity <= 0)
                {
                    Console.WriteLine("Insufficient Product's Quantity.");
                    sqlConnection.Close();
                    return;
                }

                SqlCommand insertSaleCMD = new SqlCommand(baseQuery, sqlConnection);
                int insertSaleResult = insertSaleCMD.ExecuteNonQuery();
                if (insertSaleResult > 0)
                {
                    SqlCommand updateProductCMD = new SqlCommand(updateProductQuery, sqlConnection);
                    int updateProductResult = updateProductCMD.ExecuteNonQuery();
                    string message = updateProductResult > 0 ? "Sale Inserted and Products Updated Successfully." : "Sale Inserted but Products Update Failed.";
                    Console.WriteLine(message);
                }
                else
                {
                    Console.WriteLine("Sale Insert Failed.");
                }
            }
            sqlConnection.Close();
        }
    }
}
