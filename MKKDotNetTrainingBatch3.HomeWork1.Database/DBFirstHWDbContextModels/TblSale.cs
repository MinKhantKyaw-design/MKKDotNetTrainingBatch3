using System;
using System.Collections.Generic;

namespace MKKDotNetTrainingBatch3.HomeWork1.Database.DBFirstHWDbContextModels;

public partial class TblSale
{
    public int SaleId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public bool DeleteFlag { get; set; }

    public DateTime CreatedDateTime { get; set; }

    public virtual TblProduct Product { get; set; } = null!;
}
