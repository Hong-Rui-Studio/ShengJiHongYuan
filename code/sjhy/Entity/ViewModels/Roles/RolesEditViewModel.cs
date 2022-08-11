using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ViewModels.Roles
{
    public class RolesEditViewModel
    {
        [Required]
        public int RolesId { get; set; }

        [Required(ErrorMessage= "{0}不能为空")]
        [Display(Name = "身份名称")]
        public string RolesTitle { get; set; }

    }
}
