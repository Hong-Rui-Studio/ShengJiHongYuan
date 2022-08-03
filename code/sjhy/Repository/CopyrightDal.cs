using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CopyrightDal : BaseDal<Copyright>, ICopyrightDal
    {
        public CopyrightDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
