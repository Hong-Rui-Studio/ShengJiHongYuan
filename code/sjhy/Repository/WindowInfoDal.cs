

namespace Repository
{
    public class WindowInfoDal : BaseDal<WindowInfo>, IWindowInfoDal
    {
        public WindowInfoDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
