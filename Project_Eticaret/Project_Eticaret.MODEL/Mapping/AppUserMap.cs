using Project_Eticaret.CORE.Mapping;
using Project_Eticaret.MODEL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Eticaret.MODEL.Mapping
{
    public class AppUserMap : CoreMap<AppUser>
    {
        public AppUserMap()
        {
            ToTable("dbo.Users");
            Property(x => x.Name).HasMaxLength(50).IsOptional();
            Property(x => x.SurName).HasMaxLength(50).IsOptional();
            Property(x => x.UserName).HasMaxLength(50).IsRequired();
            Property(x => x.Password).HasMaxLength(50).IsRequired();
            Property(x => x.Email).HasMaxLength(100).IsOptional();
            Property(x => x.Address).IsOptional();
            Property(x => x.BirthDate).HasColumnType("datetime2").IsOptional();
            Property(x => x.ImagePath).IsOptional();
            Property(x => x.PhoneNumber).IsOptional();
            Property(x => x.Role).IsOptional();
        }
    }
}
