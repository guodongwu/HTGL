using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Management.Entity
{
    /// <summary>
    /// 收藏表
    /// </summary>
    public class Favorite
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FID { get; set; }
        /// <summary>
        /// 收藏标题
        /// </summary>
        [MaxLength(50)]
        public string FavoriteTitle { get; set; }
        /// <summary>
        /// 收藏时间
        /// </summary>
        public Nullable<DateTime> FavoriteAddTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(200)]
        public string FavoriteContent { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserUID { get; set; }
        public virtual User User { get; set; }
        /// <summary>
        /// 操作人ID
        /// </summary>
        public Nullable<int> CreateUserID { get; set; }
        /// <summary>
        /// 收藏地址
        /// </summary>
        [MaxLength(100)]
        [Display(Name = "收藏地址")]
        public string Url { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        [MaxLength(100)]
        [Display(Name = "收藏图标")]
        public string Icon { get; set; }

    }
}

