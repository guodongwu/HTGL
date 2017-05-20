using Management.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Management.ViewModel
{
    public class UITree
    {
        public int id { get; set; }
        public string text { get; set; }
        public string desc { get; set; }
        public List<UITree> children { get; set; }
        public string icon { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented,
new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

        }
        public static UITree ToEntity(Role role)
        {
            UITree item = new UITree();
            item.id = role.RID;
            item.text = role.RoleName;
            item.desc = role.Description;
            return item;
        }
        /// <summary>
        /// 实体转化
        /// </summary>
        /// <param name="department"></param>
        public static UITree ToEntity(Department department)
        {
            UITree item = new UITree();
            item.id = department.DID;
            item.text = department.DeptName;
            item.desc = department.DeptDescription;
            // gridTree.children = new List<LigerUIGridTree>();
            return item;
        }
        public static IEnumerable<UITree> ToListViewModel(IEnumerable<Role> listRoles)
        {
            List<UITree> list = new List<UITree>();
            foreach (Role role in listRoles)
            {
                list.Add(ToEntity(role));
            }
            return list;

        }
    }
}
