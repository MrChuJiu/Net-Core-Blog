using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Blog.Core.Models
{
    /// <summary>
    /// 技术分类
    /// </summary>
    public class TechnologyClassifyInfo
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 父ID
        /// </summary>
        public int PID { get; set; }
        /// <summary>
        /// 类型名称
        /// </summary>
        public string Name { get; set; }
    }
}
