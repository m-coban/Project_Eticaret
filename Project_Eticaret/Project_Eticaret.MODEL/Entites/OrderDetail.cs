using Project_Eticaret.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Eticaret.MODEL.Entites
{
    public class OrderDetail : CoreEntity
    {
        public Guid ProductID { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? Quantity { get; set; }

        //Bir sipariş detayında bir ürün olabilir
        public virtual Product Product { get; set; }

        // Bir sipariş detayı bir Order'a ait olabilir
        public virtual Order Order { get; set; }

    }
}
