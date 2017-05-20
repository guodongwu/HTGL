using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Management.Entity
{
    /// <summary>
    /// 角色表
    /// </summary>
    public class Role
    {
        /// <summary>
        /// RoleID
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RID { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        [MaxLength(30)]
        [Display(Name = "角色名称")]
        [Required(ErrorMessage = "请输入角色名称")]
        public string RoleName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(200)]
        public string Description { get; set; }
        /// <summary>
        /// 排序值
        /// </summary>
        public Nullable<int> Sort { get; set; }
        /// <summary>
        /// 是否可见
        /// </summary>
        public Nullable<bool> IsVisible { get; set; }
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

