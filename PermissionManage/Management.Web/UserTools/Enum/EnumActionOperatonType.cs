using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Management.Web
{
    /// <summary>
    /// 定义操作类型
    /// </summary>
    public class EnumActionOperatonType
    {
        /// <summary>
        /// 添加
        /// </summary>
        public const string ADD = " 添加 ";
        /// <summary>
        /// 修改
        /// </summary>
        public const string UPDATE = " 修改 ";
        /// <summary>
        /// 软删除
        /// </summary>
        public const string DELETE = " 软删除 ";
        /// <summary>
        /// 永久删除
        /// </summary>
        public const string REALDELETE = " 永久删除 ";
        /// <summary>
        /// 查询
        /// </summary>
        public const string SELECT = " 查询 ";
        /// <summary>
        /// 登录
        /// </summary>
        public const string LOGIN = " 登录 ";

        /// <summary>
        /// MenusButtonManageControll,菜单按钮权限管理
        /// </summary>
        public const string MenusButtonManage = "[菜单按钮权限管理]";
        /// <summary>
        /// ButtonControll,权限动作信息管理
        /// </summary>
        public const string Button = "[权限动作信息管理]";
        /// <summary>
        /// DepartmentControll,部门管理
        /// </summary>
        public const string Department = "[部门管理]";
        /// <summary>
        /// MenusControll,菜单管理
        /// </summary>
        public const string Menus = "[菜单管理]";
        /// <summary>
        /// RolePermissionControll,角色权限管理
        /// </summary>
        public const string RolePermission = "[角色权限管理]";
        /// <summary>
        /// RoleControll,角色管理
        /// </summary>
        public const string Role = "[角色管理]";
        /// <summary>
        /// OperateLogControll,操作日志管理
        /// </summary>
        public const string OperateLog = "[操作日志管理]";
        /// <summary>
        /// 用户管理
        /// </summary>
        public const string User = "[用户管理]";
        /// <summary>
        /// 公共字典表数据维护
        /// </summary>
        public const string PublicDictionary = "[公共字典表数据维护]";
    }
}