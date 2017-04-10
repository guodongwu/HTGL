using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HTGL.Component.Tools;

namespace HTGL.Model{
  
    /// <summary>
    /// 实体类 组织表
    /// </summary>
    public partial class SysOrganize : EntityBase<int>
    {
        /// <summary>  
        /// 构造函数 
        /// </summary>      
        public SysOrganize(){
        
        }
        
        /// <summary>  
        /// 组织主键  
        /// </summary>      
        /// 
         [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string OrganizeId {get;set;}
        
        /// <summary>  
        /// 父级  
        /// </summary>      
        public string ParentId {get;set;}
        
        /// <summary>  
        /// 层次  
        /// </summary>      
        public int? Layers {get;set;}
        
        /// <summary>  
        /// 编码  
        /// </summary>      
        public string EnCode {get;set;}
        
        /// <summary>  
        /// 名称  
        /// </summary>      
        public string FullName {get;set;}
        
        /// <summary>  
        /// 简称  
        /// </summary>      
        public string ShortName {get;set;}
        
        /// <summary>  
        /// 分类  
        /// </summary>      
        public string CategoryId {get;set;}
        
        /// <summary>  
        /// 负责人  
        /// </summary>      
        public string ManagerId {get;set;}
        
        /// <summary>  
        /// 电话  
        /// </summary>      
        public string TelePhone {get;set;}
        
        /// <summary>  
        /// 手机  
        /// </summary>      
        public string MobilePhone {get;set;}
        
        /// <summary>  
        /// 微信  
        /// </summary>      
        public string WeChat {get;set;}
        
        /// <summary>  
        /// 传真  
        /// </summary>      
        public string Fax {get;set;}
        
        /// <summary>  
        /// 邮箱  
        /// </summary>      
        public string Email {get;set;}
        
        /// <summary>  
        /// 归属区域  
        /// </summary>      
        public string AreaId {get;set;}
        
        /// <summary>  
        /// 联系地址  
        /// </summary>      
        public string Address {get;set;}
        
        /// <summary>  
        /// 允许编辑  
        /// </summary>      
        public bool? AllowEdit {get;set;}
        
        /// <summary>  
        /// 允许删除  
        /// </summary>      
        public bool? AllowDelete {get;set;}
        
        /// <summary>  
        /// 排序码  
        /// </summary>      
        public int? SortCode {get;set;}
        
        /// <summary>  
        /// 删除标志  
        /// </summary>      
        public bool? DeleteMark {get;set;}
        
        /// <summary>  
        /// 有效标志  
        /// </summary>      
        public bool? EnabledMark {get;set;}
        
        /// <summary>  
        /// 描述  
        /// </summary>      
        public string Description {get;set;}
        
        /// <summary>  
        /// 创建时间  
        /// </summary>      
        public DateTime? CreatorTime {get;set;}
        
        /// <summary>  
        /// 创建用户  
        /// </summary>      
        public string CreatorUserId {get;set;}
        
        /// <summary>  
        /// 最后修改时间  
        /// </summary>      
        public DateTime? LastModifyTime {get;set;}
        
        /// <summary>  
        /// 最后修改用户  
        /// </summary>      
        public string LastModifyUserId {get;set;}
        
        /// <summary>  
        /// 删除时间  
        /// </summary>      
        public DateTime? DeleteTime {get;set;}
        
        /// <summary>  
        /// 删除用户  
        /// </summary>      
        public string DeleteUserId {get;set;}
        
    }
    
}
