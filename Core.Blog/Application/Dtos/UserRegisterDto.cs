using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Blog.Application.Dtos
{
    public class UserRegisterDto
    {

        [RequiredAttribute]
        [MinLength(2, ErrorMessage = "用户名必填")]
        [DisplayName("用户名")]
        public string UserName { get; set; }

        [RequiredAttribute]
        [MinLength(5, ErrorMessage = "邮箱不存在")]
        [DisplayName("邮箱")]
        public string Email { get; set; }

        [RequiredAttribute]
        [DisplayName("密码")]
        [MinLength(5, ErrorMessage = "密码错误")]
        public string PassWord { get; set; }

        public string BlogUrl { get; set; }

        public string LoveSentence { get; set; }

        public string HeadUrl { get; set; }

    }
}
