using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Management.Entity;

namespace Management.ViewModel
{
    public class ViewModelUser : User
    {
        /// <summary>
        /// 性别特殊处理
        /// </summary>
        public string sexValue { get; set; }
        /// <summary>
        /// 角色特殊处理
        /// </summary>
        public string userRoles { get; set; }

        /// <summary>
        /// 实体转换
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ViewModelUser ToViewModel(User entity)
        {
            ViewModelUser viewModel = new ViewModelUser();
            var modulePropertys = entity.GetType().GetProperties();
            var viewModelPropertys = viewModel.GetType().GetProperties();
            foreach (var vm in viewModelPropertys)
            {
                var mp = modulePropertys.Where(t => t.Name == vm.Name).SingleOrDefault();
                if (mp != null)
                    vm.SetValue(viewModel, mp.GetValue(entity, null), null);
            }
            viewModel.sexValue = entity.Sex.HasValue && entity.Sex.Value ? "1" : "0";
            return viewModel;
        }
    }
}
