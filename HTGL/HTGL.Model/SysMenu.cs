using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HTGL.Component.Tools;

namespace HTGL.Model
{

    /// <summary>
    /// 实体类 
    /// </summary>
    public partial class SysMenu : EntityBase<int>
    {
        /// <summary>  
        /// 构造函数 
        /// </summary>      
        public SysMenu()
        {

        }

        /// <summary>  
        ///   
        /// </summary>     
        /// 
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MenuId { get; set; }

        /// <summary>  
        /// 菜单名  
        /// </summary>      
        public string Name { get; set; }

        /// <summary>  
        /// 类型  
        /// </summary>      
        public byte? Type { get; set; }

        /// <summary>  
        /// 地址  
        /// </summary>      
        public string Url { get; set; }

        /// <summary>  
        /// 图标  
        /// </summary>      
        public string Icon { get; set; }

        /// <summary>  
        /// 排序  
        /// </summary>      
        public byte? Sort { get; set; }

        /// <summary>  
        /// 上级菜单  
        /// </summary>      
        public int ParentMenuId { get; set; }
        /// <summary>
        /// 菜单的控制器
        /// </summary>
        public string MenuController { get; set; }

        /// <summary>
        /// 可用
        /// </summary>
        public bool IsVisible { get; set; }
        /// <summary>
        /// 是否为菜单
        /// </summary>
        public bool IsMenu { get; set; }

        /// <summary>
        /// 是否为 
        /// </summary>
        public bool IsLeaf { get; set; }
    }

}
