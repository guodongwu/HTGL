using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Management.Entity
{
    /// <summary>
    /// User
    /// </summary>
    public class User
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UID { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "用户名")]
        [Required(ErrorMessage = "请输入用户名")]
        public string UserName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "用户密码")]
        [Required(ErrorMessage = "请输入密码")]
        public string UserPassword { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        public Nullable<int> DepartmentDID { get; set; }
        public Department Department { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "手机号")]
        public string Phone { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "邮箱")]
        public string Email { get; set; }
        /// <summary>
        /// QQ
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "QQ")]
        public string QQ { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "昵称")]
        public string NickName { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "地址")]
        public string Address { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "真实姓名")]
        public string RealName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [Display(Name = "性别")]
        public Nullable<bool> Sex { get; set; }
        /// <summary>
        /// 上次登录时间
        /// </summary>
        public Nullable<DateTime> LastLoginTime { get; set; }
        /// <summary>
        /// 操作人ID
        /// </summary>
        public Nullable<int> CreateUserID { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 是否可见
        /// </summary>
        public bool IsVisible { get; set; }
    }
}

