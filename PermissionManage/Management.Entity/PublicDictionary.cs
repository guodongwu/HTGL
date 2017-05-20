using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Management.Entity
{
    /// <summary>
    /// 公共字典表数据
    /// </summary>
    public class PublicDictionary
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PID { get; set; }

        /// <summary>
        /// 分组名称
        /// </summary>
        [MaxLength(50)]
        public string PubGroupName { get; set; }

        /// <summary>
        /// 键值
        /// </summary>
        [MaxLength(50)]
        public string PubKey { get; set; }

        /// <summary>
        /// Value值
        /// </summary>
        [MaxLength(50)]
        public string PubValue { get; set; }

        /// <summary>
        /// 是否可见
        /// </summary>
        public Nullable<bool> IsVisible { get; set; }

        /// <summary>
        /// 排序值
        /// </summary>
        public Nullable<int> Sort { get; set; }
    }
}
