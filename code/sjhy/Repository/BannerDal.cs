using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BannerDal : BaseDal<Banner>, IBannerDal
    {
        public BannerDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
