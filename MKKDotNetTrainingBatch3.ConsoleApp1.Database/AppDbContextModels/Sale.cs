using System;
using System.Collections.Generic;

namespace MKKDotNetTrainingBatch3.ConsoleApp1.Database.AppDbContextModels;

public partial class Sale
{
    public int SaleId { get; set; }

    public string? CustomerName { get; set; }

    public DateTime? SaleDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public bool? DeleteFlag { get; set; }
}
