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

        /// <summary>  
        ///   
        /// </summary>      
        public string Description { get; set; }

        /// <summary>  
        ///   
        /// </summary>      
        public int? AddUserId { get; set; }

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
        public byte? Order { get; set; }


    }

}
