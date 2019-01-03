
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Blog.Core.Models
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }
        /// <summary>
        /// 加密Key
        /// </summary>
        public string PassKey { get; set; }

        /// <summary>
        /// 其他博客链接
        /// </summary>
        public string BlogUrl { get; set; }
        /// <summary>
        /// 喜欢的一句话
        /// </summary>
        public string LoveSentence { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string HeadUrl { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 上次登录时间
        /// </summary>
        public DateTime LastErrTime { get; set; }
        /// <summary>
        /// 用户权限
        /// </summary>
        public string Role { get; set; }


        public virtual ICollection<UserCollectInfo> UserCollectInfos { get; set; }
    }
}
