using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CompanyHonorDal : BaseDal<CompanyHonor>, ICompanyHonorDal
    {
        public CompanyHonorDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
