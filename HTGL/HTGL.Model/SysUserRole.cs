﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HTGL.Component.Tools;

namespace HTGL.Model{
  
    /// <summary>
    /// 实体类 
    /// </summary>
    public partial class SysUserRole : EntityBase<int>
    {
        /// <summary>  
        /// 构造函数 
        /// </summary>      
        public SysUserRole(){
        
        }
         [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int URId { get; set; }
        /// <summary>  
        ///   
        /// </summary>      
        public int UserId {get;set;}
        
        /// <summary>  
        ///   
        /// </summary>      
        public int RoleId {get;set;}
        
        /// <summary>  
        ///   
        /// </summary>      
        public bool Status {get;set;}
        
        /// <summary>  
        ///   
        /// </summary>      
        public DateTime? AddTime {get;set;}
        
        /// <summary>  
        ///   
        /// </summary>      
        public string AddIP {get;set;}
        
        /// <summary>  
        ///   
        /// </summary>      
        public string Description {get;set;}
        
        /// <summary>  
        ///   
        /// </summary>      
        public int? AddUserId {get;set;}
        
    }
    
}