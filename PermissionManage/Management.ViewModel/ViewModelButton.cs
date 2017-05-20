using Management.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Management.ViewModel
{
    public class ViewModelButton:Permission
    {
        public List<ViewModelButton> children { get; set; }
        /// <summary>
        /// 实体转换
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ViewModelButton ToViewModel(Permission entity)
        {
            ViewModelButton viewModel = new ViewModelButton();
            var modulePropertys = entity.GetType().GetProperties();
            var viewModelPropertys = viewModel.GetType().GetProperties();
            foreach (var vm in viewModelPropertys)
            {
                var mp = modulePropertys.Where(t => t.Name == vm.Name).SingleOrDefault();
                if (mp != null)
                    vm.SetValue(viewModel, mp.GetValue(entity, null), null);
            }
            return viewModel;
        }
    }
}
