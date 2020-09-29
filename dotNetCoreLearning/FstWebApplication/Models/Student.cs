using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FstWebApplication.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "请输入名字")]
        [MaxLength(50, ErrorMessage = "名字长度不能超过50")]
        [Display(Name = "名字")]
        public string Name { get; set; }

        [Required(ErrorMessage = "请输入班级")]
        [Display(Name = "班级")]
        public ClassNameEnum? ClassName { get; set; }

        [Display(Name = "邮箱地址")]
        [Required(ErrorMessage = "请输入邮箱地址")]
        public string Email { get; internal set; }
    }
}
