using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos
{
    public class AdminsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BornDate { get; set; }

        public int Age
        {
            get
            {
                return DateTime.Now.Year - BornDate.Year;
            }
        }

        public int Gender { get; set; }

        public string Email { get; set; }

        public string Tel { get; set; }

        public string Photo { get; set; }

        public int RolesId { get; set; }

        public string UpdateTime { get; set; }





    }
}
