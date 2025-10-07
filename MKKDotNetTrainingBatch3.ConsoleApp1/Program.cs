using Microsoft.Data.SqlClient;
using System.Data;

SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();

//sqlConnectionStringBuilder.DataSource = ".";
//sqlConnectionStringBuilder.InitialCatalog = "MKKBatch3MiniPOS"; // database name
//sqlConnectionStringBuilder.UserID = "sa";
//sqlConnectionStringBuilder.Password = "P@ssw0rd";
//sqlConnectionStringBuilder.TrustServerCertificate = true;
// (or)
sqlConnectionStringBuilder.ConnectionString = "Data Source=.;Initial Catalog=MKKBatch3MiniPOS;User ID=sa;Password=P@ssw0rd;TrustServerCertificate=true";

SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

connection.Open();

string query = @"SELECT [ProductID]
      ,[ProductName]
      ,[Price]
      ,[DeleteFlag]
  FROM [dbo].[Products]";

//SqlCommand sqlCommand = connection.CreateCommand();
//sqlCommand.CommandText = query;
// (or)
SqlCommand sqlCommand = new SqlCommand(query, connection);

SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
DataTable dt = new DataTable();
adapter.Fill(dt); // execute the query and fill the DataTable

connection.Close();

for (int i = 0; i < dt.Rows.Count; i++)
{
    DataRow row = dt.Rows[i];
    int rowNo = i + 1;
    decimal price = Convert.ToDecimal(row["Price"]);
    Console.WriteLine(rowNo.ToString() + ". " + row["ProductName"] + " (" + price.ToString("n0") + ")");
}
