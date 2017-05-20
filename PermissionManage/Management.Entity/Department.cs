using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Management.Entity
{
    /// <summary>
    /// 部门
    /// </summary>
    public class Department
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DID { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        [MaxLength(30)]
        [Required(ErrorMessage = "请输入部门名称")]
        [Display(Name = "部门名称")]
        public string DeptName { get; set; }
        /// <summary>
        /// 部门描述
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "部门描述")]
        public string DeptDescription { get; set; }
        /// <summary>
        /// 父级ID
        /// </summary>
        public Nullable<int> ParentID { get; set; }
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

