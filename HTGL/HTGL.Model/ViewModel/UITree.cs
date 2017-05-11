using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTGL.Model
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
        public static UITree ToEntity(SysRole role)
        {
            UITree item = new UITree();
            item.id = role.RoleId;
            item.text = role.Name;
            item.desc = role.Desc;
            return item;
        }
        /// <summary>
        /// 实体转化
        /// </summary>
        /// <param name="department"></param>
        public static UITree ToEntity(SysDepartment department)
        {
            UITree item = new UITree();
            item.id = department.DeptId;
            item.text = department.DeptName;
            item.desc = department.DeptDesc;
            // gridTree.children = new List<LigerUIGridTree>();
            return item;
        }
        public static IEnumerable<UITree> ToListViewModel(IEnumerable<SysRole> listRoles)
        {
            List<UITree> list = new List<UITree>();
            foreach (SysRole role in listRoles)
            {
                list.Add(ToEntity(role));
            }
            return list;

        }
    }
}
