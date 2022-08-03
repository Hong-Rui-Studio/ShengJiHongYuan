using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MeasuringRulerTimeDal : BaseDal<MeasuringRulerTime>, IMeasuringRulerTimeDal
    {
        public MeasuringRulerTimeDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
