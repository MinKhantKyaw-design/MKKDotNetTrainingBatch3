using System;
using System.Collections.Generic;

namespace MKKDotNetTrainingBatch3.HomeWork1.Database.DBFirstHWDbContextModels;

public partial class TblProduct
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public bool DeleteFlag { get; set; }

    public int Quantity { get; set; }

    public DateTime CreatedDateTime { get; set; }

    public DateTime? ModifiedDateTime { get; set; }

    public virtual ICollection<TblSale> TblSales { get; set; } = new List<TblSale>();
}
