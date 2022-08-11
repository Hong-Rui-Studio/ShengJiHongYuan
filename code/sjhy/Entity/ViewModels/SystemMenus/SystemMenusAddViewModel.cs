using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ViewModels.SystemMenus
{
    public class SystemMenusAddViewModel 
    {
        [Required(ErrorMessage ="{0}不能为空")]
        [Display(Name = "菜单名称")]
        public string Title { get; set; }
        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "菜单名称")]
        public string Link { get; set; }

        public string? Icon { get; set; }

        public int FirstSelect { get; set; }

        public int? SecondSelect { get; set; }

    }
}
