using Demo.Domain;
using Demo.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Demo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly Ispt_monitorService spt_monitorService;
        public HomeController(Ispt_monitorService spt_monitorService)
        {
            this.spt_monitorService = spt_monitorService;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Send(TargetForm target)
        {
            var aa = spt_monitorService.CheckIsForgetInfo(target);
            return View();
        }


    }
}