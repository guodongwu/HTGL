using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HTGL.Component.Tools;

namespace HTGL.Model{
  
    /// <summary>
    /// 实体类 
    /// </summary>
    public partial class SysRole : EntityBase<int>
    {
        /// <summary>  
        /// 构造函数 
        /// </summary>      
        public SysRole(){
        
        }
        
        /// <summary>  
        ///   
        /// </summary>      
         [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId {get;set;}
        
        /// <summary>  
        /// 角色名  
        /// </summary>      
        public string Name {get;set;}
        
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
        public bool Status {get;set;}
        
        /// <summary>  
        ///   
        /// </summary>      
        public byte? Order {get;set;}


        public string Desc { get; set; }
    }
    
}
