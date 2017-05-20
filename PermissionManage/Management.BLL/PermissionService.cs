using Management.Dao;
using Management.Entity;
using Management.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Management.BLL
{
    public class PermissionService
    {
        PermissionDao dao = null;
        public PermissionService()
        {
            dao = new PermissionDao();
        }
        /// <summary>
        /// 获取Controll权限信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UIGrid GetPermissionForGrid(UIGridRequest request, string controllName)
        {
            int count = 0;
            var data = dao.GetPermissionForPaging(request.PageNumber, request.PageSize, controllName, out count);
            return new UIGrid()
            {
                Rows = data,
                Total = count
            };
        }

        /// <summary>
        /// 获得权限树
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UIGrid GetPermissionGridTree()
        {
            var data = dao.GetPermissionForPaging();
            int count = data.Count();
            //GetPermission(request, out count);
            List<ViewModelButton> listPermission = new List<ViewModelButton>();
            //查找所有的一级权限
            var ParentPermission = data.Where(con => con.ParentID.Value == 0);
            foreach (var parent in ParentPermission)
            {
                //实体转化 
                ViewModelButton parentItem = ViewModelButton.ToViewModel(parent);
                //获取子级
                GetPermissionChildren(ref parentItem, data.ToList());
                listPermission.Add(parentItem);
            }
            return new UIGrid()
            {
                Rows = listPermission,
                Total = count
            };

        }
        /// <summary>
        /// 获取子集
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="allList"></param>
        public void GetPermissionChildren(ref ViewModelButton parent, List<Permission> allList)
        {
            foreach (Permission permission in allList)
            {
                if (permission.ParentID == parent.PID)
                {

                    //实体转化
                    ViewModelButton child = ViewModelButton.ToViewModel(permission);
                    if (parent.children == null)
                        parent.children = new List<ViewModelButton>();
                    //添加到父级的Children中
                    parent.children.Add(child);
                    GetPermissionChildren(ref child, allList);//递归添加子树
                }
            }
        }

        /// <summary>
        /// 新增权限
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Add(Permission entity)
        {
            return dao.Insert(entity);
        }

        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(Permission entity)
        {
            return dao.Modify(entity);
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(Permission entity)
        {
            return dao.Remove(entity.PID);
        }
    }
}
