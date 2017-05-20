use ManagementDB
go

--部门
delete from Departments
INSERT [dbo].[Departments] ( [DeptName], [DeptDescription], [ParentID], [CreateUserID], [CreateDate],  [IsVisible]) VALUES (N'web开发部门', N'开发互联网应用', 0, NULL, NULL,1)
INSERT [dbo].[Departments] ( [DeptName], [DeptDescription], [ParentID], [CreateUserID], [CreateDate],  [IsVisible]) VALUES (N'Silverlight部门', N'开发Silverlight富媒体应用', 1, NULL, NULL,1)
INSERT [dbo].[Departments] ( [DeptName], [DeptDescription], [ParentID], [CreateUserID], [CreateDate],  [IsVisible]) VALUES (N'asp.net部门', N'开发asp.net网站', 1, NULL, NULL,1)
INSERT [dbo].[Departments] ( [DeptName], [DeptDescription], [ParentID], [CreateUserID], [CreateDate],  [IsVisible]) VALUES (N'jsp部门', N'开发jsp网站', 1, NULL, NULL,1)
--菜单
delete from Modules
select * from Modules
INSERT [dbo].[Modules] ([ModuleName], [ModuleLinkUrl], [ModuleIcon], [ParentID], [Sort], [IsVisible], [IsLeaf], [IsMenu], [ModuleController]) VALUES (N'系统管理', NULL, N'/Content/icons/32X32/settings.gif', 0, 0, 1, 0, 1, NULL)
INSERT [dbo].[Modules] ([ModuleName], [ModuleLinkUrl], [ModuleIcon], [ParentID], [Sort], [IsVisible], [IsLeaf], [IsMenu], [ModuleController]) VALUES (N'部门管理', N'/Department/Index', N'/Content/icons/32X32/customers.gif', 5, 1, 1, 1, 1, N'Department')
INSERT [dbo].[Modules] ([ModuleName], [ModuleLinkUrl], [ModuleIcon], [ParentID], [Sort], [IsVisible], [IsLeaf], [IsMenu], [ModuleController]) VALUES (N'用户管理', N'/User/Index', N'/Content/icons/32X32/user.gif', 5, 2, 1, 1, 1, N'User')
INSERT [dbo].[Modules] ([ModuleName], [ModuleLinkUrl], [ModuleIcon], [ParentID], [Sort], [IsVisible], [IsLeaf], [IsMenu], [ModuleController]) VALUES (N'角色管理', N'/Role/Index', N'/Content/icons/32X32/role.gif', 5, 3, 1, NULL, 1, N'Role')
INSERT [dbo].[Modules] ([ModuleName], [ModuleLinkUrl], [ModuleIcon], [ParentID], [Sort], [IsVisible], [IsLeaf], [IsMenu], [ModuleController]) VALUES (N'组织架构', NULL, N'/Content/icons/32X32/sitemap.gif', 0, 0, 1, NULL, 1, NULL)
INSERT [dbo].[Modules] ([ModuleName], [ModuleLinkUrl], [ModuleIcon], [ParentID], [Sort], [IsVisible], [IsLeaf], [IsMenu], [ModuleController]) VALUES (N'系统日志管理', N'/OperateLog/Index', N'/Content/icons/32X32/project.gif', 1, 1, 1, 1, 1, N'OperateLog')
INSERT [dbo].[Modules] ([ModuleName], [ModuleLinkUrl], [ModuleIcon], [ParentID], [Sort], [IsVisible], [IsLeaf], [IsMenu], [ModuleController]) VALUES (N'菜单管理', N'/Menus/Index', N'/Content/icons/32X32/sitemap.gif', 1, 2, 1, 1, 1, N'Menus')
INSERT [dbo].[Modules] ([ModuleName], [ModuleLinkUrl], [ModuleIcon], [ParentID], [Sort], [IsVisible], [IsLeaf], [IsMenu], [ModuleController]) VALUES (N'系统权限维护', N'/Button/Index', N'/Content/icons/32X32/config.gif', 1, 3, 1, NULL, 1, N'Button')
INSERT [dbo].[Modules] ([ModuleName], [ModuleLinkUrl], [ModuleIcon], [ParentID], [Sort], [IsVisible], [IsLeaf], [IsMenu], [ModuleController]) VALUES (N'菜单按钮管理', N'/MenusButtonsManage/Index', N'/Content/icons/32X32/feed.gif', 1, 4, 1, NULL, 0, N'MenusButtonsManage')
INSERT [dbo].[Modules] ([ModuleName], [ModuleLinkUrl], [ModuleIcon], [ParentID], [Sort], [IsVisible], [IsLeaf], [IsMenu], [ModuleController]) VALUES ( N'角色权限管理', N'/RolePermission/Index', N'/Content/icons/32X32/setup.gif', 1, 5, 1, 0, 1, N'RolePermission')
INSERT [dbo].[Modules] ([ModuleName], [ModuleLinkUrl], [ModuleIcon], [ParentID], [Sort], [IsVisible], [IsLeaf], [IsMenu], [ModuleController]) VALUES ( N'公共字典表维护', N'/PublicDictionary/Index', N'/Content/icons/32X32/database.gif', 5, NULL, 1, NULL, 1, N'PublicDictionary')


--角色
delete from Roles
INSERT [dbo].[Roles] (  [RoleName], [Description], [Sort], [IsVisible], [CreateUserID], [CreateDate]) VALUES ( N'超级管理员', N'具备所有权限，无需配置 ', 1, 1, NULL, NULL)
INSERT [dbo].[Roles] (  [RoleName], [Description], [Sort], [IsVisible], [CreateUserID], [CreateDate]) VALUES (N'普通管理员', N'需要进行配置权限', 2, 1, NULL, NULL)

--具体权限
delete from Permissions
select * from Permissions
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'Index', N'访问部门管理', NULL, 1, N'/Content/icons/32X32/customers.gif', N'Department', N'[Index主页]部门管理', 0, 0)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'Index', N'访问权限维护', NULL, 1, N'/Content/icons/32X32/feed.gif', N'Button', N'[系统权限维护页]按钮管理', 0, 0)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'Index', N'访问日志管理', NULL, 1, N'/Content/icons/32X32/project.gif', N'OperateLog', N'[Index主页]系统操作日志管理', 0, 0)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'Index', N'访问用户信息', NULL, 1, N'/Content/icons/32X32/user.gif', N'User', N'[用户管理首页]列表信息', 0, 0)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'Index', N'访问角色管理', NULL, 1, N'/Content/icons/32X32/role.gif', N'Role', N'[角色管理首页]', 0, 0)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'Index', N'访问菜单管理', NULL, 1, N'/Content/icons/32X32/sitemap.gif', N'Menus', N'[Index主页]菜单管理', 0, 0)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'Index', N'访问菜单按钮管理', NULL, 1, N'/Content/icons/32X32/feed.gif', N'MenusButtonsManage', N'[菜单按钮管理主页]', 0, 0)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'Index', N'访问角色权限管理', NULL, 1, N'/Content/icons/32X32/setup.gif', N'RolePermission', N'角色权限管理', 0, 0)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'Update', N'修改部门', NULL, 1, N'/Content/icons/silkicons/application_edit.png', N'Department', N'[Index页面Update请求]更新部门', 1, 1)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'Add', N'添加部门', NULL, 1, N'/Content/icons/silkicons/add.png', N'Department', N'[Index页面Add请求]添加部门', 1, 1)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'Delete', N'删除部门', NULL, 1, N'/Content/icons/silkicons/delete.png', N'Department', N'[Index页面Delete请求]删除(假删)部门', 1, 1)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'DeleteThreeMonthLog', N'清空日志', NULL, 1, N'/Content/icons/silkicons/book_delete.png', N'OperateLog', N'[Index页面删除请求]清空三个月以前的日志', 1, 3)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'RealDelete', N'永久删除菜单', NULL, 1, N'/Content/icons/silkicons/application_delete.png', N'Menus', N'[Index页面永久删除请求]永久删除', 1, 6)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'GetLogsGrid', N'获取日志列表信息', NULL, 1, N'/Content/icons/silkicons/delete.png', N'OperateLog', N'[Index页面Grid请求]获取系统操作日志信息(首页必须)', 0, 3)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'Update', N'修改菜单', NULL, 1, N'/Content/icons/silkicons/application_edit.png', N'Menus', N'[Index页面Update更新请求]更新菜单', 1, 6)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'Add', N'添加菜单', NULL, 1, N'/Content/icons/silkicons/add.png', N'Menus', N'[Index页面Add添加请求]添加菜单', 1, 6)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'Delete', N'删除菜单', NULL, 1, N'/Content/icons/silkicons/delete.png', N'Menus', N'[Index页面Delete删除请求]删除', 1, 6)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'Update', N'修改', NULL, 1, N'/Content/icons/silkicons/application_edit.png', N'Button', N'[系统权限维护页]修改动作', 1, 2)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'Add', N'添加', NULL, 1, N'/Content/icons/silkicons/add.png', N'Button', N'[系统权限维护页]添加动作', 1, 2)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'Delete', N'删除', NULL, 1, N'/Content/icons/silkicons/delete.png', N'Button', N'[系统权限维护页]软删除动作', 1, 2)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'RealDelete', N'永久删除', NULL, 1, N'/Content/icons/silkicons/application_delete.png', N'Button', N'[系统权限维护页]永久删除动作', 1, 2)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'MenuButtonConfig', N'菜单按钮管理', NULL, 1, N'/Content/icons/silkicons/cog.png', N'Menus', N'[Index页面跳转]菜单按钮管理', 1, 6)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'RealDelete', N'永久删除', NULL, 1, N'/Content/icons/silkicons/application_delete.png', N'MenusButtonsManage', N'[菜单按钮管理主页]永久删除动作', 1, 7)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'Update', N'修改', NULL, 1, N'/Content/icons/silkicons/application_edit.png', N'MenusButtonsManage', N'[菜单按钮管理主页]修改请求', 1, 7)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'Add', N'添加', NULL, 1, N'/Content/icons/silkicons/add.png', N'MenusButtonsManage', N'[菜单按钮管理主页]添加请求', 1, 7)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'Delete', N'删除', NULL, 1, N'/Content/icons/silkicons/delete.png', N'MenusButtonsManage', N'[菜单按钮管理主页]删除(假删除)', 1, 7)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'Add', N'添加角色', NULL, 1, N'/Content/icons/silkicons/application_edit.png', N'Role', N'[角色管理首页]添加角色', 1, 5)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'Update', N'修改角色', NULL, 1, N'/Content/icons/silkicons/add.png', N'Role', N'[角色管理首页]修改角色', 1, 5)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'Delete', N'删除', NULL, 1, N'/Content/icons/silkicons/delete.png', N'Role', N'[角色管理首页]删除(假删)角色', 1, 5)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'RealDelete', N'永久删除', NULL, 1, N'/Content/icons/silkicons/application_delete.png', N'Role', N'[角色管理首页]永久删除角色', 1, 5)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'Detail', N'查看详情', NULL, 1, N'/Content/icons/silkicons/application_view_detail.png', N'User', N'[用户详细信息]详细信息(add,Update,Detail必备)', 1, 4)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'Update', N'修改', NULL, 1, N'/Content/icons/silkicons/application_edit.png', N'User', N'[用户详细信息]更新用户', 1, 4)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'Add', N'添加', NULL, 1, N'/Content/icons/silkicons/add.png', N'User', N'[用户详细信息]添加用户', 1, 4)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'Delete', N'删除', NULL, 1, N'/Content/icons/silkicons/delete.png', N'User', N'[用户详细信息]删除用户', 1, 4)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'GrantRolePermission', N'授予权限', NULL, 1, N'/Content/icons/silkicons/table_gear.png', N'RolePermission', N'授予角色权限', 1, 8)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'GetDeptGridTree', N'获取部门GridTree树信息', NULL, 1, N'/Content/icons/32X32/communication.gif', N'Department', N'[Index页面GridTree Ajax请求]获取部门GridTree树信息(主页必须)', 0, 1)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'GetDeptSelect', N'获取部门列表下拉框信息', NULL, 1, N'/Content/icons/32X32/shipping.gif', N'Department', N'[Detail页面Select Ajax请求]获取部门的下拉列表框(Detail,Update,Add必须)', 0, 1)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'Get', N'获取一条部门记录信息', NULL, 1, N'/Content/icons/32X32/shipping.gif', N'Department', N'[Detail页面加载表单请求]获取一条部门信息(Detail,Update必须)', 0, 1)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'GetDepartmentTree', N'部门下拉框请求', NULL, 1, N'/Content/icons/32X32/shipping.gif', N'Department', N'部门树级下拉框请求', 0, 1)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'GetPermissionForGrid', N'获取权限信息', NULL, 1, N'/Content/icons/32X32/communication.gif', N'Button', N'[系统权限维护页Ajax请求]请求权限功能列表信息(返回Grid)(主页必须)', 0, 2)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'SelectAction', N'选择动作主页', NULL, 1, N'/Content/icons/32X32/feed.gif', N'Button', N'[选择动作页面]请求动作信息页面(Add和Update必须)', 0, 2)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'GetAllAction', N'获取所有动作信息', NULL, 1, N'/Content/icons/32X32/feed.gif', N'Button', N'[选择动作页面Grid Ajax请求]请求所有控制器的动作信息(Add和Update必须)', 0, 78)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'GetLogsGrid', N'查询', NULL, 1, N'/Content/icons/32X32/search.gif', N'OperateLog', N'[Index页面Grid请求]获取系统操作日志信息(首页必须)', 1, 3)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'Index', N'访问公共字典表管理', NULL, 1, N'/Content/icons/32X32/database.gif', N'PublicDictionary', N'[Index首页]公共字典表维护', 0, 0)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'Add', N'添加公共字典表数据', NULL, 1, N'/Content/icons/32X32/plus.gif', N'PublicDictionary', N'[Index页面添加请求]添加公共字典表数据', 1, 46)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'Update', N'修改公共字典表数据', NULL, 1, N'/Content/icons/32X32/pen.gif', N'PublicDictionary', N'[Index页面修改请求]修改公共字典表数据', 1, 46)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'Delete', N'删除公共字典表数据', NULL, 1, N'/Content/icons/32X32/busy.gif', N'PublicDictionary', N'[Index页面修改请求]屏蔽公共字典表数据', 1, 46)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'RealDelete', N'永久删除公共字典表', NULL, 1, N'/Content/icons/32X32/busy.gif', N'PublicDictionary', N'[Index页面删除请求]永久删除公共字典表数据', 1, 46)
INSERT [dbo].[Permissions] ( [PermissionAction], [PermissionName], [Sort], [IsVisible], [Icon], [PermissionController], [Description], [IsButton], [ParentID]) VALUES ( N'GetSearchData', N'查询公共字典表数据', NULL, 1, N'/Content/icons/32X32/search.gif', N'PublicDictionary', N'[Index页面获取数据请求]Grid加载数据', 1, 46)


--模块权限表
delete from ModulePermissions
select * from ModulePermissions
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES (2, 1, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES (2, 9, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES (2, 10, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES (2, 11, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES (2, 36, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES (2, 37, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES (2, 28, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES (2, 39, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES (8, 2, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES ( 8, 18, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES ( 8, 19, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES ( 8, 20, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES ( 8, 21, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES ( 8, 40, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES ( 8, 41, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES ( 8, 42, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES ( 6, 3, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES ( 6, 12, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES ( 6, 14, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES ( 3, 4, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES ( 3, 31, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES ( 3, 32, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES ( 3, 33, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES ( 3, 34, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES ( 4, 5, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES ( 4, 27, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES ( 4, 28, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES ( 4, 29, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES ( 4, 30, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES ( 7, 6, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES ( 7, 12, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES ( 7, 15, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES ( 7, 16, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES ( 7, 17, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES ( 7, 22, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES ( 10, 8, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES ( 10, 35, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES ( 9, 7, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES ( 9, 23, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES ( 9, 24, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES ( 9, 25, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES ( 9, 26, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES ( 1, NULL, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES ( 5, NULL, NULL, NULL, 1)
INSERT [dbo].[ModulePermissions] ( [ModuleMId], [PermissionPId], [CreateUserID], [CreateDate], [IsVisible]) VALUES ( 6, 46, 1, NULL, 0)

--用户表
INSERT INTO [dbo].[Users]([UserName],[UserPassword],[DepartmentDID],[Phone],[Email],[QQ],[NickName],[Address],[RealName],[Sex],[LastLoginTime],[CreateUserID],[CreateDate],[IsVisible]) VALUES('admin','6c7ddc69e527e34ce74499fae46cb11',Null,Null,Null,Null,'admin',Null,Null,0,GETDATE(),0,GETDATE(),1)

--用户角色表
delete from UserRoles
INSERT [dbo].[UserRoles] ( [UserUID], [RoleRID], [CreateUserID], [CreateDate] ) VALUES ( 1, 1, NULL, NULL)