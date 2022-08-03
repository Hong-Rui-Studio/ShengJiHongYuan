using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DecorationStageDal : BaseDal<DecorationStage>, IDecorationStageDal
    {
        public DecorationStageDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
