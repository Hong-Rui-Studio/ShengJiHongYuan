using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CompanyCulturesDal : BaseDal<CompanyCultures>, ICompanyCulturesDal
    {
        public CompanyCulturesDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
