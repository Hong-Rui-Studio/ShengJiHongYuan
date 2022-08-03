using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrdersDal : BaseDal<Orders>, IOrdersDal
    {
        public OrdersDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
