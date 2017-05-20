using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Management.BLL;
using Management.Entity;
using Management.ViewModel;

namespace Management.Web.Controllers
{
    [Description("公共字典表维护管理")]
    public class PublicDictionaryController : BaseController
    {
        [Description("[Index首页]公共字典表维护")]
        [DefaultPage]
        [ViewPage]
        public ActionResult Index()
        {
            return View();
        }

        [Description("[Index页面添加请求]添加公共字典表数据")]
        [UIExceptionResult]
        public ActionResult Add(PublicDictionary entity)
        {
            PublicDictionaryService servie = new PublicDictionaryService();
            entity.IsVisible = true;
            var state = servie.Add(entity);
            UserOperateLogHelper.WriteOperateLog(EnumActionOperatonType.PublicDictionary, EnumActionOperatonType.ADD, state);
            return this.Content(EnumActionExecutedStatus.Success.ToString());
        }

        [Description("[Index页面修改请求]修改公共字典表数据")]
        [UIExceptionResult]
        public ActionResult Update(PublicDictionary entity)
        {
            PublicDictionaryService service = new PublicDictionaryService();
            entity.IsVisible = true;
            var state = service.Update(entity);
            UserOperateLogHelper.WriteOperateLog(EnumActionOperatonType.PublicDictionary, EnumActionOperatonType.UPDATE, state);
            return this.Content(EnumActionExecutedStatus.Success.ToString());
        }

        [Description("[Index页面修改请求]屏蔽公共字典表数据")]
        [UIExceptionResult]
        public ActionResult Delete(PublicDictionary entity)
        {
            PublicDictionaryService service = new PublicDictionaryService();
            entity.IsVisible = false;
            var state = service.Update(entity);
            UserOperateLogHelper.WriteOperateLog(EnumActionOperatonType.PublicDictionary, EnumActionOperatonType.DELETE, state);
            return this.Content(EnumActionExecutedStatus.Success.ToString());
        }

        [Description("[Index页面删除请求]永久删除公共字典表数据")]
        [UIExceptionResult]
        public ActionResult RealDelete()
        {
            var pid = HttpContext.Request["PID"];
            int id = 0; int.TryParse(pid, out id);
            PublicDictionaryService service = new PublicDictionaryService();
            var state = service.Delete(id);
            UserOperateLogHelper.WriteOperateLog(EnumActionOperatonType.PublicDictionary, EnumActionOperatonType.REALDELETE, state);
            return this.Content(EnumActionExecutedStatus.Success.ToString());
        }

        [Description("[Index页面获取数据请求]Grid加载数据")]
        [UIExceptionResult]
        public ActionResult GetSearchData()
        {
            UIGridRequest request = new UIGridRequest(HttpContext);
            var groupName = HttpContext.Request["GroupName"];
            var pubValue = HttpContext.Request["PubValue"];
            PublicDictionaryService servie = new PublicDictionaryService();
            return this.Json(servie.GetAllPublicDictionary(request, groupName, pubValue));
        }
    }
}
