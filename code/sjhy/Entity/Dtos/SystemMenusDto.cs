using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos
{
    public class SystemMenusDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Icon { get; set; }
        public int ParentId { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
