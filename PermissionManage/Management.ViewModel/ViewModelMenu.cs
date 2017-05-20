using Management.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Management.ViewModel
{
    public class ViewModelMenu : Module
    {
        /// <summary>
        /// 前四个是ligerui必须参数(大小写也要一样)
        /// </summary>
        public string icon { get; set; }

        public int id { get; set; }

        public string text { get; set; }

        public List<ViewModelMenu> children { get; set; }

        /// <summary>
        /// 实体转换
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ViewModelMenu ToViewModel(Module entity)
        {
            ViewModelMenu viewModel = new ViewModelMenu();
            var modulePropertys = entity.GetType().GetProperties();
            var viewModelPropertys = viewModel.GetType().GetProperties();
            foreach (var vm in viewModelPropertys)
            {
                var mp = modulePropertys.Where(t => t.Name == vm.Name).SingleOrDefault();
                if (mp != null)
                    vm.SetValue(viewModel, mp.GetValue(entity, null), null);
            }
            viewModel.id = entity.MID;
            viewModel.text = entity.ModuleName;
            viewModel.icon = entity.ModuleIcon;
            return viewModel;
        }
    }
}
