
namespace Repository
{
    public class ServicesIdeaDal : BaseDal<ServicesIdea>, IServicesIdeaDal
    {
        public ServicesIdeaDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
