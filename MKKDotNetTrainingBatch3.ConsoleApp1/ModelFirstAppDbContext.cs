using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKKDotNetTrainingBatch3.ConsoleApp1
{
    public class ModelFirstAppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new()
            {
                DataSource = ".",
                InitialCatalog = "MKKBatch3MiniPOS",
                UserID = "sa",
                Password = "P@ssw0rd",
                TrustServerCertificate = true
            };
            optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<Tbl_Product> Products { get; set; }
    }

    [Table("Tbl_Products")]
    public class Tbl_Product
    {
        [Key]
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public bool DeleteFlag { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime? ModifiedDateTime { get; set; }
    }
}
