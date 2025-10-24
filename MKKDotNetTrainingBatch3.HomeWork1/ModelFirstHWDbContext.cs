using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MKKDotNetTrainingBatch3.HomeWork1
{
    public class ModelFirstHWDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "MKKBatch3MiniPOS",
                UserID = "sa",
                Password = "P@ssw0rd",
                TrustServerCertificate = true
            };
            optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<Tbl_Products> Tbl_Products {  get; set; }
        public DbSet<Tbl_Sales> Tbl_Sales { get; set; }
    }

    public class Tbl_Products
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool DeleteFlag { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
    }

    public class Tbl_Sales()
    {
        [Key]
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool DeleteFlag { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
