using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Eticaret.UI.Areas.Member.Data.VM
{
    public class ProductVM
    {
        public Guid ID { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitInStock { get; set; }
        public short Quantity { get; set; }
        public string ImagePath { get; set; }

    }
}