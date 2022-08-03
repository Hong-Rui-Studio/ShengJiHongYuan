using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ServiceProcessDal : BaseDal<ServiceProcess>, IServiceProcessDal
    {
        public ServiceProcessDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
