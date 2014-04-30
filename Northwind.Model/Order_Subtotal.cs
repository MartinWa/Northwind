using System;
using System.Collections.Generic;

namespace Northwind.Model.Models
{
    public partial class Order_Subtotal
    {
        public int OrderID { get; set; }
        public Nullable<decimal> Subtotal { get; set; }
    }
}
