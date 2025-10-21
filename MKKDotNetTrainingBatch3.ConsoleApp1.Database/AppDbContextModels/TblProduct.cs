using System;
using System.Collections.Generic;

namespace MKKDotNetTrainingBatch3.ConsoleApp1.Database.AppDbContextModels;

public partial class TblProduct
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public decimal? Price { get; set; }

    public bool? DeleteFlag { get; set; }

    public int? Quantity { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? ModifiedDateTime { get; set; }
}
