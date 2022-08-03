using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CasesDal : BaseDal<Cases>, ICasesDal
    {
        public CasesDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
