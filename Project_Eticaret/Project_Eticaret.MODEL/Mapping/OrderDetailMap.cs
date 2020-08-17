using Project_Eticaret.CORE.Mapping;
using Project_Eticaret.MODEL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Eticaret.MODEL.Mapping
{
    public class OrderDetailMap : CoreMap<OrderDetail>
    {
        public OrderDetailMap()
        {
            ToTable("dbo.OrderDetails");
            Property(y => y.Quantity).IsOptional();
            Property(t => t.UnitPrice).IsOptional();
        }
    }
}
