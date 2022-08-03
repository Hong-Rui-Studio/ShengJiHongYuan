using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductCategoryDal : BaseDal<ProductCategory>, IProductCategoryDal
    {
        public ProductCategoryDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
