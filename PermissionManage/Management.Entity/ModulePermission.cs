using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Management.Entity
{
    /// <summary>
    /// 模块权限
    /// </summary>
    public class ModulePermission
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long MPID { get; set; }

        /// <summary>
        /// 模块ID
        /// </summary>
        [Required]
        public int ModuleMId { get; set; }

        /// <summary>
        /// 模块
        /// </summary>
        public Module Module { get; set; }

        /// <summary>
        /// 权限ID
        /// </summary>
        public Nullable<int> PermissionPId { get; set; }

        /// <summary>
        /// 权限
        /// </summary>
        //[Required]
        public Permission Permission { get; set; }

        /// <summary>
        /// 操作人ID
        /// </summary>
        public Nullable<int> CreateUserID { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public Nullable<DateTime> CreateDate { get; set; }

        /// <summary>
        /// 是否可见
        /// </summary>
        public Nullable<bool> IsVisible { get; set; }

    }
}

