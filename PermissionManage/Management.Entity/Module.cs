using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Management.Entity
{
    /// <summary>
    /// 模块表
    /// </summary>
    public class Module
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MID { get; set; }
        /// <summary>
        /// 模块名称
        /// </summary>
        [MaxLength(30)]
        [Required(ErrorMessage = "请输入模块名称")]
        [Display(Name = "模块名称")]
        public string ModuleName { get; set; }
        /// <summary>
        /// 模块链接地址
        /// </summary>
        [MaxLength(100)]
        [Display(Name = "模块地址")]
        public string ModuleLinkUrl { get; set; }
        /// <summary>
        /// 模块图标
        /// </summary>
        [MaxLength(100)]
        public string ModuleIcon { get; set; }
        /// <summary>
        /// 父级编号
        /// </summary>
        public Nullable<int> ParentID { get; set; }
        /// <summary>
        /// 排序值
        /// </summary>
        public Nullable<int> Sort { get; set; }
        /// <summary>
        /// 是否可见
        /// </summary>
        public Nullable<bool> IsVisible { get; set; }
        /// <summary>
        /// 是否叶子节点
        /// </summary>
        public Nullable<bool> IsLeaf { get; set; }
        /// <summary>
        /// 是否菜单
        /// </summary>
        public Nullable<bool> IsMenu { get; set; }
        /// <summary>
        /// 模块控制器
        /// </summary>
        [MaxLength(50)]
        public string ModuleController { get; set; }

    }
}

