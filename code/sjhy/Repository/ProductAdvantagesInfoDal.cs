using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductAdvantagesInfoDal : BaseDal<ProductAdvantagesInfo>, IProductAdvantagesInfoDal
    {
        public ProductAdvantagesInfoDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
