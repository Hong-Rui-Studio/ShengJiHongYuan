
namespace Repository
{
    public class SoleNetsDal : BaseDal<SoleNets>, ISoleNetsDal
    {
        public SoleNetsDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
