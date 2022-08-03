using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class NoticesDal : BaseDal<Notices>, INoticesDal
    {
        public NoticesDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
