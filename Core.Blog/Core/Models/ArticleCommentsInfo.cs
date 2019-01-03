using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Blog.Core.Models
{
    /// <summary>
    /// 文章评论
    /// </summary>
    public class ArticleCommentsInfo
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 文章ID
        /// </summary>
        public string PostsID { get; set; }
        /// <summary>
        /// 文章实体
        /// </summary>
        public BlogPostsInfo BlogPostsInfo { get; set; }
        /// <summary>
        /// 评论父ID
        /// </summary>
        public int PID { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }



        /// <summary>
        /// 创建人
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 创建人实体
        /// </summary>
        public virtual UserInfo UserInfo { get; set; }
    }
}
