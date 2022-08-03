using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class NewsDal : BaseDal<News>, INewsDal
    {
        public NewsDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
