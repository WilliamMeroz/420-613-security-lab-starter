using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityLab1_Starter.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        private ILogger<InventoryController> _logger;
        public InventoryController(ILogger<InventoryController> logger)
        {
            _logger = logger;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GenError()
        {
            throw new Exception();
            return View();
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            _logger.LogError(filterContext.Exception.Message);
            filterContext.Result = RedirectToAction("Index", "ErrorHandler");
        }
    }
}