using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Management.ViewModel
{
    /// <summary>
    /// 针对LigerUITree的请求
    /// </summary>
    public class UITreeRequest
    {
        /// <summary>
        ///字段查看视图(暂时没做到)
        /// </summary>
        public string View { get; set; }
        /// <summary>
        /// 筛选器
        /// </summary>
        public string Where { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public string IdField { get; set; }
        /// <summary>
        /// 父级Id
        /// </summary>
        public int PidField { get; set; }
        /// <summary>
        /// 内容字段
        /// </summary>
        public string TextField { get; set; }
        /// <summary>
        /// 图标字段
        /// </summary>
        public string IconField { get; set; }
        /// <summary>
        /// 图标根路径
        /// </summary>
        public string IconRoot { get; set; }
        /// <summary>
        /// 根
        /// </summary>
        public string Root { get; set; }
        /// <summary>
        /// 根图标
        /// </summary>
        public string RootIcon { get; set; }
        /// <summary>
        /// 构造请求
        /// </summary>
        /// <param name="context"></param>
        public UITreeRequest(HttpContextBase context)
        {
            int pid = 0;
            View = context.Request["view"];
            Where = context.Request["where"];
            IdField = context.Request["idfield"];
            PidField = int.TryParse(context.Request["pidfield"], out pid) ? pid : 0;
            TextField = context.Request["textfield"];
            IconField = context.Request["iconfield"];
            IconRoot = context.Request["iconroot"] ?? "";
            Root = context.Request["root"];
            RootIcon = context.Request["rooticon"];
        }


    }
}
