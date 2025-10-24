using System;
using System.Collections.Generic;

namespace MKKDotNetTrainingBatch3.HomeWork1.Database.DBFirstHWDbContextModels;

public partial class TblProductCategory
{
    public int ProductCategoryId { get; set; }

    public string? ProductCategoryCode { get; set; }

    public string? ProductCategoryName { get; set; }
}
