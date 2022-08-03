using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class FranchiseAdvantagesDal : BaseDal<FranchiseAdvantages>, IFranchiseAdvantagesDal
    {
        public FranchiseAdvantagesDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
