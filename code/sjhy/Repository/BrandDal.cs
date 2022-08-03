using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BrandDal : BaseDal<Brand>, IBrandDal
    {
        public BrandDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
