using HTGL.Component.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HTGL.Model
{

    /// <summary>
    /// 实体类 数据库备份
    /// </summary>
    public partial class  SysDbBackup: EntityBase<int>
    {
        /// <summary>  
        /// 构造函数 
        /// </summary>      
        public SysDbBackup(){
        
        }
        
        /// <summary>  
        /// 备份主键  
        /// </summary> 
        /// 
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BackupId {get;set;}

        /// <summary>  
        /// 备份类型  
        /// </summary>   
        /// 
        public string BackupType {get;set;}

        /// <summary>  
        /// 数据库名称  
        /// </summary>      
        public string DbName {get;set;}

        /// <summary>  
        /// 文件名称  
        /// </summary>      

        public string FileName {get;set;}

        /// <summary>  
        /// 文件大小  
        /// </summary>      
        public string FileSize {get;set;}

        /// <summary>  
        /// 文件路径  
        /// </summary>      
        public string FilePath {get;set;}

        /// <summary>  
        /// 备份时间  
        /// </summary>      
        public DateTime? BackupTime {get;set;}

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
