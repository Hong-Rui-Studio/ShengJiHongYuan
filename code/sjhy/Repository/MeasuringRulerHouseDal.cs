using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MeasuringRulerHouseDal : BaseDal<MeasuringRulerHouse>, IMeasuringRulerHouseDal
    {
        public MeasuringRulerHouseDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
