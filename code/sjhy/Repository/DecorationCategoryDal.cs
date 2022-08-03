using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DecorationCategoryDal : BaseDal<DecorationCategory>, IDecorationCategoryDal
    {
        public DecorationCategoryDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
