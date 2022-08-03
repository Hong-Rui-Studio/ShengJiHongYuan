using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductAdvantagesDal : BaseDal<ProductAdvantages>, IProductAdvantagesDal
    {
        public ProductAdvantagesDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
