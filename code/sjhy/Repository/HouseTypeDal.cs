using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class HouseTypeDal : BaseDal<HouseType>, IHouseTypeDal
    {
        public HouseTypeDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
