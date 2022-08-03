using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class WoodWindowCulturesDal : BaseDal<WoodWindowCultures>, IWoodWindowCulturesDal
    {
        public WoodWindowCulturesDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
