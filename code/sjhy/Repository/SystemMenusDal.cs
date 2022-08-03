

namespace Repository
{
    public class SystemMenusDal : BaseDal<SystemMenus>, ISystemMenusDal
    {
        public SystemMenusDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
