using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Blog.Core.Models
{
    /// <summary>
    /// 收藏表
    /// </summary>
    public class UserCollectInfo
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 收藏人ID
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 收藏人实体
        /// </summary>
        public UserInfo UserInfo { get; set; }

        /// <summary>
        /// 收藏ID
        /// </summary>
        public int CollID { get; set; }
        /// <summary>
        /// 收藏类型 0、用户  1、文章
        /// </summary>
        public int CollType { get; set; }
    }
}
