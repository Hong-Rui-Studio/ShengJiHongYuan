

namespace Repository
{
    public class TechnicalEquipmentDal : BaseDal<TechnicalEquipment>, ITechnicalEquipmentDal
    {
        public TechnicalEquipmentDal(MyContext cxt) : base(cxt)
        {
        }
    }
}
