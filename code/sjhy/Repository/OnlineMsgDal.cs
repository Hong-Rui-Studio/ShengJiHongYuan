using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OnlineMsgDal : BaseDal<OnlineMsg>, IOnlineMsgDal
    {
        public OnlineMsgDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
