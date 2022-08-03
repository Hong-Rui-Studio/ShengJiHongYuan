

namespace Repository
{
    public class WebMenusDal : BaseDal<WebMenus>, IWebMenusDal
    {
        public WebMenusDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
