using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Planru.Modules.Directory.Persistence;
using Planru.Modules.Directory.Domain.Entities;
using Microsoft.Practices.Unity;
using System.Web.Routing;
using System.Data.Entity;

namespace Planru.DistributedServices.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            //MainUnitOfWork uow = new MainUnitOfWork();
            //var userRepository = new UserRepository(uow);
            //userRepository.Add(new User() { FirstName = "Liep", LastName = "Nguyen" });
            //userRepository.UnitOfWork.Commit();


            return View();
        }

        public ActionResult Restart() {
            HttpRuntime.UnloadAppDomain();
            return RedirectToAction("Index");
        }
    }
}
