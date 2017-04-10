using HTGL.Service.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTGL.Model;
using HTGL.Service.Interface;

namespace HTGL.UI.Portal.Areas.Cms.Controllers
{
    public class SysDbBackupController :Controller
    {
        ISysDbBackupService _sysDbBackupService;
        public SysDbBackupController(ISysDbBackupService sysDbBackupService)
        {
            _sysDbBackupService = sysDbBackupService;

        }
        public ActionResult Index()
        {
           
            var list = _sysDbBackupService.FindAll();

            return View(list);
        }

    }
}
