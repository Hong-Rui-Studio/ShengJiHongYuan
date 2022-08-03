using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ContactsDal : BaseDal<Contacts>, IContactsDal
    {
        public ContactsDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
