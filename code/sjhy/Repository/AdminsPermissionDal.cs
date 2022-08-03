using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AdminsPermissionDal : BaseDal<AdminsPermission>, IAdminsPermissionDal
    {
        public AdminsPermissionDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
