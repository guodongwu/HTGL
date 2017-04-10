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
    public partial class SysDict : EntityBase<int>
    {
        /// <summary>  
        /// 构造函数 
        /// </summary>      
        public SysDict()
        {

        }

        /// <summary>  
        ///   
        /// </summary>   
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DictId { get; set; }

        /// <summary>  
        ///   
        /// </summary>      
        public int? DictParentId { get; set; }

        /// <summary>  
        ///   
        /// </summary>      
        public string DictName { get; set; }

        /// <summary>  
        ///   
        /// </summary>      
        public string DictKey { get; set; }

        /// <summary>  
        ///   
        /// </summary>      
        public string DictValue { get; set; }

        /// <summary>  
        ///   
        /// </summary>      
        public string DictType { get; set; }

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
