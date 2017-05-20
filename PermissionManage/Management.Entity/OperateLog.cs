using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management.Entity
{
    /// <summary>
    /// 操作日志
    /// </summary>
    public class OperateLog
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OID { get; set; }
        /// <summary>
        /// 控制器名称
        /// </summary>
        [MaxLength(50)]
        public string ProcessName { get; set; }
        /// <summary>
        /// 控制器描述
        /// </summary>
        [MaxLength(100)]
        public string ProcessDesc { get; set; }
        /// <summary>
        /// 动作名称
        /// </summary>
        [MaxLength(50)]
        public string MethodName { get; set; }
        /// <summary>
        /// 操作人姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        /// <summary>
        /// 操作人ID
        /// </summary>
        public int UserUID { get; set; }
        public virtual User User { get; set; }
        /// <summary>
        /// 操作人IP
        /// </summary>
        [MaxLength(100)]
        public string IPAddress { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(200)]
        public string Description { get; set; }
        /// <summary>
        /// 操作日期
        /// </summary>
        public Nullable<DateTime> CreateDate { get; set; }
        /// <summary>
        /// 方法描述
        /// </summary>
        [MaxLength(100)]
        public string MethodDesc { get; set; }

    }
}

