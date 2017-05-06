using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HTGL.Model
{
    public class SysMenuVM
    {
        /// <summary>
        /// 前四个是ligerui必须参数(大小写也要一样)
        /// </summary>
        public string Icon { get; set; }

        public int ID { get; set; }

        public string Text { get; set; }

        public int ParentID { get; set; }
        public string LinkUrl { get; set; }
        public string MenuController { get; set; }
        public List<SysMenuVM> Children { get; set; }

        /// <summary>
        /// 实体转换
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static SysMenuVM ToViewModel(SysMenu entity)
        {
            SysMenuVM viewModel = new SysMenuVM();
            var modulePropertys = entity.GetType().GetProperties();
            var viewModelPropertys = viewModel.GetType().GetProperties();
            foreach (var vm in viewModelPropertys)
            {
                var mp = modulePropertys.SingleOrDefault(t => t.Name == vm.Name);
                if (mp != null)
                    vm.SetValue(viewModel, mp.GetValue(entity, null), null);
            }
            viewModel.ID = entity.MenuId;
            viewModel.Text = entity.Name;
            viewModel.Icon = entity.Icon;
            viewModel.ParentID = entity.ParentMenuId;
            viewModel.LinkUrl = entity.Url;
            viewModel.MenuController = entity.MenuController;
            return viewModel;
        }
    }

}