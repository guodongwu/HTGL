using Management.Dao;
using Management.Entity;
using Management.Tools;
using Management.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Management.BLL
{
    public class UserService
    {
        UserDao dao = null;
        public UserService()
        {
            dao = new UserDao();
        }

        #region 用户信息
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="loginName">登陆姓名</param>
        /// <param name="loginPwd">登陆密码</param>
        /// <returns></returns>
        public User Login(string loginName, string loginPwd)
        {
            loginPwd = MD5Helper.ConvertMD5(MD5Helper.ConvertMD5(loginPwd) + loginName.ToUpper());
            return dao.Login(loginName, loginPwd);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="requestInfo"></param>
        /// <returns></returns>
        public bool ChangePassword(UserRequest requestInfo, int UserID)
        {
            User user = dao.GetUserInfoByUID(UserID);
            if (MD5Helper.ConvertMD5(MD5Helper.ConvertMD5(user.UserPassword) + user.UserName) ==
                MD5Helper.ConvertMD5(MD5Helper.ConvertMD5(requestInfo.OldPassord) + requestInfo.UserName))
                return dao.ChangePassword(user, requestInfo.NewPassword);
            else
                return false;
        }
        /// <summary>
        /// 根据用户ID获取用户角色
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public string GetUserAllRole(int UID)
        {
            UserRoleService service = new UserRoleService();
            var roles = service.GetUserRole(UID);
            var rolesStr = "";
            foreach (var item in roles)
            {
                if (!String.IsNullOrEmpty(rolesStr))
                    rolesStr += ",";
                rolesStr += item.RoleRID;
            }
            return rolesStr;
        }

        /// <summary>
        /// 根据用户ID获取用户信息
        /// </summary>
        /// <param name="uID"></param>
        /// <returns></returns>
        public User GetUserInfoByUID(int uID)
        {
            return dao.GetUserInfoByUID(uID);
        }
        #endregion


        #region 权限校验
        /// <summary>
        /// 角色是否拥有该操作权限
        /// </summary>
        /// <param name="Roles">角色组</param>
        /// <param name="Controller">控制器</param>
        /// <param name="Action">动作</param>
        /// <returns></returns>
        public bool RoleHasOperatePermission(string Roles, string Controller, string Action)
        {
            List<int> list = new List<int>();
            if (!string.IsNullOrEmpty(Roles))
                Roles.Split(',').ToList().ForEach(item => list.Add(int.Parse(item)));
            return dao.RoleHasOperatePermission(list, Controller, Action);
        }
        /// <summary>
        /// 角色是否拥有该菜单模块权限
        /// </summary>
        /// <param name="Roles">角色组</param>
        /// <param name="Controller">控制器</param>
        /// <param name="Action">动作</param>
        /// <returns></returns>
        public bool RoleHasMenusPermission(string Roles, string Controller)
        {
            List<int> list = new List<int>();
            if (!string.IsNullOrEmpty(Roles))
                Roles.Split(',').ToList().ForEach(item => list.Add(int.Parse(item)));
            return dao.RoleHasMenusPermission(list, Controller);
        }
        #endregion

        #region 用户菜单
        /// <summary>
        /// 获取指定角色(多个)的菜单
        /// </summary>
        /// <param name="roles">角色组(多个角色用,分隔开)</param>
        /// <returns></returns>
        public IEnumerable<Module> GetRoleMenu(string roles, int adminRoleId)
        {
            List<int> list = new List<int>();
            if (!string.IsNullOrEmpty(roles))
                roles.Split(',').ToList().ForEach(item => list.Add(int.Parse(item)));
            if (list.Contains(adminRoleId))
                return dao.GetAllPermissonMenus();
            else
                return dao.GetPermissonMenusByRoles(list);
        }
        /// <summary>
        /// 获取用户的菜单
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public IEnumerable<ViewModelMenu> GetUserPermissionMenus(string roles, int adminRoleId)
        {
            List<ViewModelMenu> menusList = new List<ViewModelMenu>();
            //获取当前角色的json菜单数据
            IEnumerable<Module> RolesMenus = GetRoleMenu(roles, adminRoleId);
            //首先找出父级菜单
            var ParentMenus = RolesMenus.Where(p => p.ParentID == 0);
            foreach (Module roleMenu in ParentMenus)
            {
                ViewModelMenu roleMenuParent = ViewModelMenu.ToViewModel(roleMenu);
                //添加子菜单
                foreach (Module childMenu in RolesMenus)
                {
                    ViewModelMenu childViewMenu = ViewModelMenu.ToViewModel(childMenu);
                    if (childViewMenu.ParentID == roleMenuParent.MID)
                    {
                        if (roleMenuParent.children == null)
                            roleMenuParent.children = new List<ViewModelMenu>();
                        roleMenuParent.children.Add(childViewMenu);
                    }
                }
                menusList.Add(roleMenuParent);
            }
            return menusList;

        }


        /// <summary>
        /// 请求一级菜单树
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IEnumerable<ViewModelMenu> GetUserTreeMenus(UITreeRequest request, string userRoles)
        {
            //返回ui层的菜单
            IEnumerable<ViewModelMenu> rootMenus = new List<ViewModelMenu>(){
            new ViewModelMenu()
            {
                icon = request.RootIcon,
                ModuleIcon = request.RootIcon,
                ParentID = request.PidField,
                ModuleName = "主菜单",
                MID = !string.IsNullOrEmpty(request.IdField)?int.Parse(request.IdField):0,
                text = "主菜单",
                children = (new ModuleService().GetFirstMenu().ToList()) 
            }};
            return rootMenus;
        }

        /// <summary>
        /// 获取请求的Grid菜单列表
        /// </summary>
        /// <param name="request">请求</param>
        /// <param name="userRoles">角色组</param>
        /// <param name="parentNo">父级编号</param>
        /// <param name="Count">总记录数</param>
        /// <returns></returns>
        public IEnumerable<Module> GetUserGridMenus(UIGridRequest request, string userRoles, int parentNo, out int Count)
        {
            List<int> list = new List<int>();
            if (!string.IsNullOrEmpty(userRoles))
                userRoles.Split(',').ToList().ForEach(item => list.Add(int.Parse(item)));
            return dao.GetAllMenusForPaging(request.PageNumber, request.PageSize, list, parentNo, out Count);
        }

        /// <summary>
        /// 获取请求的Grid菜单列表的LigeruiGrid格式
        /// </summary>
        /// <param name="request"></param>
        /// <param name="userRoles"></param>
        /// <param name="AdminUserRoleID">超级管理员角色ID</param>
        /// <returns></returns>
        public UIGrid GetUserGridMenus(UIGridRequest request, string userRoles, int parentNo, string AdminUserRoleID)
        {
            int total = 0;
            UIGrid grid = new UIGrid();
            //验证是否拥有超级管理员角色,如果是则返回所有菜单
            if (!ToolsHelper.CheckStringHasValue(userRoles, ',', AdminUserRoleID))
                grid.Rows = GetUserGridMenus(request, userRoles, parentNo, out total);
            else
                grid.Rows = new ModuleService().GetAdminMenus(request, parentNo, out total);

            //记录总数
            grid.Total = total;
            //返回ui层的菜单
            return grid;

        }

        #endregion

        #region 获取角色指定菜单的按钮信息
        /// <summary>
        /// 获取角色指定菜单的按钮信息
        /// </summary>
        /// <param name="Roles">角色信息</param>
        /// <param name="adminRole">超级管理员角色</param>
        /// <param name="menuNo">请求信息</param>
        /// <returns></returns>
        public IEnumerable<Permission> GetButtons(string Roles, int adminRole, string menuNo)
        {
            List<int> list = new List<int>();
            if (!string.IsNullOrEmpty(Roles))
                Roles.Split(',').ToList().ForEach(item => list.Add(int.Parse(item)));
            if (list.Contains(adminRole))
                return dao.GetUserModulePermission(menuNo);
            else
                return dao.GetUserModulePermission(list, menuNo);
        }
        #endregion

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <param name="requestGrid"></param>
        /// <returns></returns>
        public UIGrid GetAllUsers(UIGridRequest requestGrid)
        {
            int count = 0;
            var data = dao.GetAllUsers(requestGrid.PageNumber, requestGrid.PageSize, out count);
            return new UIGrid() { Rows = data, Total = count };
        }

        /// <summary>
        /// 获取用户名数量
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public int GetCount(string userName)
        {
            return dao.GetCount(userName);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="userIDs">用户ID</param>
        /// <returns></returns>
        public bool Insert(User entity, string userIDs)
        {
            List<int> list = new List<int>();
            if (!String.IsNullOrEmpty(userIDs))
                foreach (var item in userIDs.Split(','))
                {
                    int itemId = -1;
                    if (int.TryParse(item, out itemId))
                        list.Add(itemId);
                }
            //加密密码
            entity.UserPassword = MD5Helper.ConvertMD5(MD5Helper.ConvertMD5(entity.UserPassword) + entity.UserName.ToUpper());
            return dao.Add(entity, list);
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="userIDs">用户ID</param>
        /// <returns></returns>
        public bool Update(User entity, string userIDs)
        {
            List<int> list = new List<int>();
            foreach (var item in userIDs.Split(','))
            {
                int itemId = -1;
                if (int.TryParse(item, out itemId))
                    list.Add(itemId);
            }
            return dao.Modify(entity, list);
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public bool Update(User entity)
        {
            return dao.Modify(entity);
        }

        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public bool Delete(User entity)
        {
            return dao.Remove(entity);
        }
    }
}
