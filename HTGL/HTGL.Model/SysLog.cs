using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HTGL.Component.Tools;

namespace HTGL.Model{
  
    /// <summary>
    /// 实体类 
    /// </summary>
    public partial class SysLog : EntityBase<int>
    {
        /// <summary>  
        /// 构造函数 
        /// </summary>      
        public SysLog(){
        
        }
        
        /// <summary>  
        ///   
        /// </summary>      
         [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LogId {get;set;}
        
        /// <summary>  
        ///   
        /// </summary>      
        public int UserId {get;set;}
        
        /// <summary>  
        ///   
        /// </summary>      
        public string UserName {get;set;}
        
        /// <summary>  
        ///   
        /// </summary>      
        public string OperatingType {get;set;}
        
        /// <summary>  
        ///   
        /// </summary>      
        public DateTime OperatingTime {get;set;}
        
        /// <summary>  
        ///   
        /// </summary>      
        public string Event {get;set;}
        
        /// <summary>  
        ///   
        /// </summary>      
        public string OperatingIp {get;set;}
        
        /// <summary>  
        ///   
        /// </summary>      
        public int? MenuId {get;set;}
        
        /// <summary>  
        ///   
        /// </summary>      
        public string MenuName {get;set;}
        
        /// <summary>  
        ///   
        /// </summary>      
        public int? FunctionId {get;set;}
        
        /// <summary>  
        ///   
        /// </summary>      
        public string FunctionName {get;set;}
        
        /// <summary>  
        ///   
        /// </summary>      
        public string OperatingResult {get;set;}
        
        /// <summary>  
        ///   
        /// </summary>      
        public string OperatingDesc {get;set;}

        public  string ProcessName { get; set; }

        public  string ProcessDesc { get; set; }

        public  string MethodName { get; set; }
        public virtual SysUser SysUser { get; set; }
        
    }
    
}
