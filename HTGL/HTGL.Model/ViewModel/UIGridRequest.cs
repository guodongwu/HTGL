using System.Web;
namespace HTGL.Model
{

    /// <summary>
    /// 针对UIGridRequest
    /// </summary>
    public class UIGridRequest
    {
        private int pageSize;

        private int pageNumber;
        /// <summary>
        /// 页号
        /// </summary>
        public int PageNumber
        {
            get
            {
                if (this.pageNumber <= 0)
                    return 1;
                else
                    return pageNumber;
            }
            set
            {
                if (value <= 0)
                    pageNumber = 1;
                else
                    pageNumber = value;
            }
        }
        /// <summary>
        /// 每页的多少条数据
        /// </summary>
        public int PageSize
        {
            get
            {
                return this.pageSize;
            }
            set
            {
                this.pageSize = (value == 0 ? 10 : value);
            }
        }
        /// <summary>
        /// 排序字段名称
        /// </summary>
        public string SortName { get; set; }
        /// <summary>
        /// 初始化读取信息
        /// </summary>
        /// <param name="context"></param>
        public UIGridRequest(HttpContextBase context)
        {
            this.SortName = context.Request["sortname"];
            int pageNum = 1; int.TryParse(context.Request["page"], out pageNum);
            this.PageNumber = pageNum;
            int pageSize = 10; int.TryParse(context.Request["pagesize"], out pageSize);
            this.PageSize = pageSize;
        }
    }

}