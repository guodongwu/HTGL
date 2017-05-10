using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HTGL.Component.Tools;
using Newtonsoft.Json;

namespace HTGL.Model
{

    /// <summary>
    /// 实体类 
    /// </summary>
    public partial class SysFunction : EntityBase<int>
    {
        /// <summary>  
        /// 构造函数 
        /// </summary>      
        public SysFunction()
        {

        }

        /// <summary>  
        ///   
        /// </summary>      
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FunctionId { get; set; }

        /// <summary>  
        /// 功能名称  
        /// </summary>      
        public string Name { get; set; }

        public  string ControllerName { get; set; }
        public  string ActionName { get; set; }
        /// <summary>  
        ///   
        /// </summary>      
        public string Description { get; set; }
        public  string Icon { get; set; }

        public  bool IsVisible { get; set; }

        public  bool IsButton { get; set; }

        /// <summary>  
        ///   
        /// </summary>      
        public int? AddUserId { get; set; }

        public int? ParentFID { get; set; }

        /// <summary>  
        ///   
        /// </summary>      
        public DateTime? AddTime { get; set; }

        /// <summary>  
        ///   
        /// </summary>      
        public string AddIp { get; set; }

        /// <summary>  
        ///   
        /// </summary>      
        public bool Status { get; set; }

        /// <summary>  
        ///   
        /// </summary>      
        public byte? Sort { get; set; }

 

    }

}
