using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ViewModels.Admins
{
    public  class AdminsEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "姓名")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [DataType(DataType.Date)]
        [Display(Name = "出生日期")]
        public DateTime BornDate { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "性别")]
        public int Gender { get; set; }
        [Required(ErrorMessage = "{0}不能为空")]
        [EmailAddress(ErrorMessage = "{0}格式不正确")]
        [Display(Name = "邮件地址")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "联系电话")]
        public string Tel { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Pwd { get; set; }

        public string? Photo { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "身份编号")]
        public int RolesId { get; set; }
    }
}
