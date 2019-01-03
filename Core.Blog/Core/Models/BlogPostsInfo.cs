using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Blog.Core.Models
{
    /// <summary>
    /// 文章
    /// </summary>
    public class BlogPostsInfo
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }


        public int TechnologyClassifyID { get; set; }
        /// <summary>
        /// 技术分类
        /// </summary>
        public virtual TechnologyClassifyInfo TechnologyClassifyInfo { get; set; }
        /// <summary>
        /// 关键词
        /// </summary>
        public string KeyWords { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; }
        /// <summary>
        /// 主要内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 评论
        /// </summary>
        public virtual ICollection<ArticleCommentsInfo>  ArticleComments { get; set; }

        /// <summary>
        /// 热度 （被收藏数）
        /// </summary>
        public int Heat { get; set; }

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
