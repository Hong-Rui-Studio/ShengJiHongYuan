

namespace Repository
{
    public class WindowCategoryDal : BaseDal<WindowCategory>, IWindowCategoryDal
    {
        public WindowCategoryDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
