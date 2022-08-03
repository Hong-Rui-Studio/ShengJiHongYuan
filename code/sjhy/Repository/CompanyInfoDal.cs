using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CompanyInfoDal : BaseDal<CompanyInfo>, ICompanyInfoDal
    {
        public CompanyInfoDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
