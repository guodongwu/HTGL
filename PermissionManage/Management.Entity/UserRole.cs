using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Management.Entity
{
    /// <summary>
    /// 用户角色表
    /// </summary>
    public class UserRole
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int URID { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserUID { get; set; }
        public virtual User User { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleRID { get; set; }
        public virtual Role Role { get; set; }
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

