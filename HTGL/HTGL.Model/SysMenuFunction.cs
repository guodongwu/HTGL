using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HTGL.Component.Tools;

namespace HTGL.Model{
  
    /// <summary>
    /// 实体类 
    /// </summary>
    public partial class SysMenuFunction : EntityBase<int>
    {
        /// <summary>  
        /// 构造函数 
        /// </summary>      
        public SysMenuFunction(){
        
        }
         [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MFId { get; set; }
        /// <summary>  
        ///   
        /// </summary>      
        public int MenuId {get;set;}
        
        /// <summary>  
        ///   
        /// </summary>      
        public int FunctionId {get;set;}
        
        /// <summary>  
        ///   
        /// </summary>      
        public bool IsVisible {get;set;}
        
        /// <summary>  
        ///   
        /// </summary>      
        public DateTime? AddTime {get;set;}
        
        /// <summary>  
        ///   
        /// </summary>      
        public string AddIp {get;set;}
        
        /// <summary>  
        ///   
        /// </summary>      
        public int? AddUserId {get;set;}
        public virtual SysFunction SysFunction { get; set; }
        public virtual SysMenu SysMenu { get; set; }
        
    }
    
}
