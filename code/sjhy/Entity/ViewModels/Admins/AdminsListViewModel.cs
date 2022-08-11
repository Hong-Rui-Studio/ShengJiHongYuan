
namespace Entity.ViewModels.Admins
{
    public class AdminsListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BornDate { get; set; }
        public int Age{ get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Photo { get; set; }

        public string RolesTitle { get; set; }

        public string UpdateTime { get; set; }
    }
}
