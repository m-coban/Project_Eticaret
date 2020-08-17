using Project_Eticaret.CORE.Mapping;
using Project_Eticaret.MODEL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Eticaret.MODEL.Mapping
{
    public class SubCategoryMap : CoreMap<SubCategory>
    {
        public SubCategoryMap()
        {
            ToTable("dbo.SubCategories");
            Property(x => x.Name).IsOptional();
            Property(x => x.Description).IsOptional();
            Property(x => x.Tag).IsOptional();

            HasMany(x => x.Products)
                .WithRequired(x => x.SubCategory)
                .HasForeignKey(x => x.SubCategoryID);
        }
    }
}
