using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class JoiningProgamDal : BaseDal<JoiningProgam>, IJoiningProgamDal
    {
        public JoiningProgamDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
