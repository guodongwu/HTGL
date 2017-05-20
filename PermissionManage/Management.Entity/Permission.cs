using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Management.Entity
{
    /// <summary>
    /// 权限表
    /// </summary>
    public class Permission
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PID { get; set; }
        /// <summary>
        /// 动作
        /// </summary>
        [MaxLength(30)]
        public string PermissionAction { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        [MaxLength(30)]
        public string PermissionName { get; set; }
        /// <summary>
        /// 排序值
        /// </summary>
        public Nullable<int> Sort { get; set; }
        /// <summary>
        /// 是否可见
        /// </summary>
        public Nullable<bool> IsVisible { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        [MaxLength(100)]
        public string Icon { get; set; }
        /// <summary>
        /// 控制器
        /// </summary>
        [MaxLength(30)]
        public string PermissionController { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(200)]
        public string Description { get; set; }
        /// <summary>
        /// 是否按钮
        /// </summary>
        public Nullable<bool> IsButton { get; set; }
        /// <summary>
        /// 父级ID
        /// </summary>
        [Required]
        public Nullable<int> ParentID { get; set; }

    }
}

