using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HTGL.Component.Tools;

namespace HTGL.Model{
  
    /// <summary>
    /// 实体类 
    /// </summary>
    public partial class SysUser : EntityBase<int>
    {
        /// <summary>  
        /// 构造函数 
        /// </summary>      
        public SysUser(){
        
        }
        
        /// <summary>  
        ///   
        /// </summary>      
         [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId {get;set;}
        
        /// <summary>  
        ///   
        /// </summary>      
        public string UserGuid {get;set;}
        
        /// <summary>  
        /// 用户名  
        /// </summary>      
        public string UserName {get;set;}
        
        /// <summary>  
        /// 真实姓名  
        /// </summary>      
        public string RealName {get;set;}
        
        /// <summary>  
        /// 密码  
        /// </summary>      
        public string Password {get;set;}
        
        /// <summary>  
        /// 身份证号  
        /// </summary>      
        public string IdCard {get;set;}
        
        /// <summary>  
        /// 头像  
        /// </summary>      
        public string Portrait {get;set;}
        
        /// <summary>  
        /// 性别  
        /// </summary>      
        public byte? Gender {get;set;}
        
        /// <summary>  
        /// 生日  
        /// </summary>      
        public DateTime? Birthday {get;set;}
        
        /// <summary>  
        /// 年龄  
        /// </summary>      
        public int? Age {get;set;}
        
        /// <summary>  
        /// 昵称  
        /// </summary>      
        public string Nick {get;set;}
        
        /// <summary>  
        /// 电话  
        /// </summary>      
        public string Phone {get;set;}
        
        /// <summary>  
        /// e-mail  
        /// </summary>      
        public string Email {get;set;}
        
        /// <summary>  
        /// 状态  
        /// </summary>      
        public bool Status {get;set;}
        
        /// <summary>  
        ///   
        /// </summary>      
        public DateTime? AddTime {get;set;}
        
        /// <summary>  
        ///   
        /// </summary>      
        public string AddIp {get;set;}
        
        /// <summary>  
        /// qq  
        /// </summary>      
        public string QQ {get;set;}
        
        /// <summary>  
        /// 登录key  
        /// </summary>      
        public string LoginKey {get;set;}
        
        /// <summary>  
        /// 登录key类型  qq weixin sina  
        /// </summary>      
        public string LoginKeyType {get;set;}
        
        /// <summary>  
        ///   
        /// </summary>      
        public string Education {get;set;}
        
        /// <summary>  
        ///   
        /// </summary>      
        public string Address {get;set;}
        
        /// <summary>  
        ///   
        /// </summary>      
        public string Nation {get;set;}
        
        /// <summary>  
        ///   
        /// </summary>      
        public string ZipCode {get;set;}
        
        /// <summary>  
        ///   
        /// </summary>      
        public string Profile {get;set;}

        /// <summary>
        /// 最后一次登录时间
        /// </summary>
        public DateTime? LastLoginTime { get; set; }
        /// <summary>
        /// 最后登录IP
        /// </summary>
        public string LastLoginIp { get; set; }
        
    }
    
}
