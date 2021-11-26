using Demo.Domain;
using Demo.Service.Interface;
using Newtonsoft.Json;
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
            var result = spt_monitorService.CheckIsForgetInfo(target);
            string message = "";
            if (result == null)
                message = "查無資料";

            string serverModel = JsonConvert.SerializeObject(result);
            string serverMessage = JsonConvert.SerializeObject(message);
            return Json(new { serverModel, serverMessage }, JsonRequestBehavior.AllowGet);
        }
    }
}