
namespace Repository
{
    public class WoodWindowSystemDal : BaseDal<WoodWindowSystem>, IWoodWindowSystemDal
    {
        public WoodWindowSystemDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
