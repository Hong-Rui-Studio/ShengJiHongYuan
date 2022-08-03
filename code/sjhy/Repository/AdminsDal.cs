using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AdminsDal : BaseDal<Admins>, IAdminsDal
    {
        public AdminsDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
