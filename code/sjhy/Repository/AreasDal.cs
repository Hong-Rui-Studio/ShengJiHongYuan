
namespace Repository
{
    public class AreasDal : BaseDal<Areas>, IAreasDal
    {
        public AreasDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
