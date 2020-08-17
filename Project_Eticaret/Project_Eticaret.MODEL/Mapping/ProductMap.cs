using Project_Eticaret.CORE.Mapping;
using Project_Eticaret.MODEL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Eticaret.MODEL.Mapping
{
    public class ProductMap : CoreMap<Product>
    {
        public ProductMap()
        {
            ToTable("dbo.Products");
            Property(x => x.Name).HasMaxLength(50).IsOptional();
            Property(x => x.Price).IsOptional();
            Property(x => x.Quantity).IsOptional();
            Property(x => x.UnitInStock).IsOptional();
            Property(x => x.ImagePath).IsOptional();

            HasRequired(x => x.SubCategory)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.SubCategoryID)
                .WillCascadeOnDelete(false); // bir subCategory silindiğinde ona bağlı olan ürünler de silinsin mi? (Hayır)
        }
    }
}
