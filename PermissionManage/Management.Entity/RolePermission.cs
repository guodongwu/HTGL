using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Management.Entity
{
    /// <summary>
    /// 角色权限表
    /// </summary>
    public class RolePermission
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RPID { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        public Nullable<int> RoleID { get; set; }
        /// <summary>
        /// 模块权限ID
        /// </summary>
        public Nullable<long> ModulePermissionID { get; set; }
        /// <summary>
        /// 操作人ID
        /// </summary>
        public Nullable<int> CreateUserID { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public Nullable<DateTime> CreateDate { get; set; }
    }
}

