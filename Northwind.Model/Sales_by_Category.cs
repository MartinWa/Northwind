using System;
using System.Collections.Generic;

namespace Northwind.Model.Models
{
    public partial class Sales_by_Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public Nullable<decimal> ProductSales { get; set; }
    }
}
