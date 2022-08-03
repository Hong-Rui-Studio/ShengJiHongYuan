using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RolesDal : BaseDal<Roles>, IRolesDal
    {
        public RolesDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
