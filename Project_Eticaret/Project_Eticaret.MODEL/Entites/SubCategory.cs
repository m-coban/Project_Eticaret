using Project_Eticaret.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Eticaret.MODEL.Entites
{
    public class SubCategory : CoreEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Tag { get; set; }
        public Guid CategoryID { get; set; }

        // 1 alt kategorinin 1 kategorisi olur
        public virtual Category Category { get; set; }

        // 1 alt kategorinin birden fazla ürünü olabilir
        public virtual List<Product> Products { get; set; }

    }
}
