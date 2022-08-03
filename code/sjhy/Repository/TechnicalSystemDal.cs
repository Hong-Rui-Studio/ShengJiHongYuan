

namespace Repository
{
    public class TechnicalSystemDal : BaseDal<TechnicalSystem>, ITechnicalSystemDal
    {
        public TechnicalSystemDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
