using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class FriendLinkDal : BaseDal<FriendLink>, IFriendLinkDal
    {
        public FriendLinkDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
