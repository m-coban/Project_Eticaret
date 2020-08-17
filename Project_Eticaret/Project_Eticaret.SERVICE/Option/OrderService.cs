using Project_Eticaret.CORE.Entity.Enum;
using Project_Eticaret.MODEL.Entites;
using Project_Eticaret.SERVICE.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Eticaret.SERVICE.Option
{
    public class OrderService : BaseService<Order>
    {
        public List<Order> ListPendingOrders()
        {
            return GetDefault(x => x.Confirmed == false && x.Status == Status.Active).OrderByDescending(x => x.CreatedDate).ToList();
        }

        public int PendingOrderCount()
        {
            return GetDefault(x => x.Confirmed == false && x.Status == Status.Active).ToList().Count;
        }
    }
}
