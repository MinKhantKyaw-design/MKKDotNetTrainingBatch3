using System;
using System.Collections.Generic;

namespace MKKDotNetTrainingBatch3.ConsoleApp1.Database.AppDbContextModels;

public partial class SalesProduct
{
    public int? SaleId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public virtual TblProduct? Product { get; set; }

    public virtual Sale? Sale { get; set; }
}
