using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Management.ViewModel
{
    public class UIGrid
    {
        /// <summary>
        /// 返回的记录
        /// </summary>
        public object Rows { get; set; }
        /// <summary>
        /// 总个数
        /// </summary>
        public int Total { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(Rows, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
