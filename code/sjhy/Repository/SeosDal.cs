using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SeosDal : BaseDal<Seos>, ISeosDal
    {
        public SeosDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
